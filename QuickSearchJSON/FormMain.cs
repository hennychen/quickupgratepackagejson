using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;

namespace QuickSearchJSON
{
    public partial class FormMain : Form
    {
        JObject jsonObject { get; set; }
        private string selectedKey { get; set; }


        private JObject jsonSource;
        private JObject jsonTarget;
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonSelectSource_Click(object sender, EventArgs e)
        {
            // 创建OpenFileDialog实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置文件过滤条件，只允许选择JSON文件
            openFileDialog.Filter = "JSON文件 (*.json)|*.json";

            // 设置对话框标题
            openFileDialog.Title = "选择JSON文件";

            // 显示OpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取用户选择的JSON文件路径
                string selectedJsonFilePath = openFileDialog.FileName;

                // 处理JSON文件路径，例如显示在文本框中
                MessageBox.Show("你选择的JSON文件路径是: " + selectedJsonFilePath);

                // 这里可以添加代码来读取和处理JSON文件
                // 例如：
                string jsonContent = System.IO.File.ReadAllText(selectedJsonFilePath);
                this.jsonSource = JObject.Parse(jsonContent);


             

            
            }
        }

        private void buttonSelectTarget_Click(object sender, EventArgs e)
        {
            // 创建OpenFileDialog实例
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 设置文件过滤条件，只允许选择JSON文件
            openFileDialog.Filter = "JSON文件 (*.json)|*.json";

            // 设置对话框标题
            openFileDialog.Title = "选择JSON文件";

            // 显示OpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 获取用户选择的JSON文件路径
                string selectedJsonFilePath = openFileDialog.FileName;

                // 处理JSON文件路径，例如显示在文本框中
                MessageBox.Show("你选择的JSON文件路径是: " + selectedJsonFilePath);

                // 这里可以添加代码来读取和处理JSON文件
                // 例如：
                string jsonContent = File.ReadAllText(selectedJsonFilePath);
              
                // 指定要获取的Key

                jsonTarget = JObject.Parse(jsonContent);

             
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (jsonSource == null || jsonTarget == null)
            {
                MessageBox.Show("请先选择两个JSON文件。");
                return;
            }
           
            // 清空列表
            listBoxCommonKeys.Items.Clear();


            // 指定要过滤掉的Key数组
            string[] keysToFilter = new string[] { "name", "version", "scripts", "husky" };
            // 递归替换子项
            ReplaceSubItems(jsonSource, jsonTarget, keysToFilter);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON文件 (*.json)|*.json",
                Title = "保存合并后的JSON文件",
                FileName = "merged.json" // 默认文件名
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilePath = saveFileDialog.FileName;
                File.WriteAllText(outputFilePath, jsonSource.ToString(Formatting.Indented));
                MessageBox.Show("JSON文件已成功保存到: " + outputFilePath);
            }
        }
        private void ReplaceSubItems(JObject source, JObject target, string[] keysToFilter)
        {
            foreach (var item in source.Children<JProperty>())
            {
                string key = item.Name;
                JToken targetToken;

                // 检查是否需要过滤掉这个Key
                if (Array.IndexOf(keysToFilter, key) >= 0)
                {
                    continue; // 跳过这个Key
                }

                if (target.TryGetValue(key, out targetToken))
                {
                    JProperty property = item;
                    if (property.Value.Type == JTokenType.Object && targetToken.Type == JTokenType.Object)
                    {
                        // 如果target中存在对应的键，并且对应的值是对象，则递归替换子项
                        ReplaceSubItems((JObject)property.Value, (JObject)targetToken, keysToFilter);
                    }
                    else
                    {
                        // 如果target中的值不是对象或者source中的值不是对象，则替换source中的值
                        source[key] = targetToken.DeepClone(); // 使用DeepClone()确保值被正确复制

                        // 如果存在相同的Key，添加到ListBox中
                        listBoxCommonKeys.Items.Add(key);
                    }
                }
            }
        }
        
    }
}