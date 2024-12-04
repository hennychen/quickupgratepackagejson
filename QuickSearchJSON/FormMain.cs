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
            // ����OpenFileDialogʵ��
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // �����ļ�����������ֻ����ѡ��JSON�ļ�
            openFileDialog.Filter = "JSON�ļ� (*.json)|*.json";

            // ���öԻ������
            openFileDialog.Title = "ѡ��JSON�ļ�";

            // ��ʾOpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ȡ�û�ѡ���JSON�ļ�·��
                string selectedJsonFilePath = openFileDialog.FileName;

                // ����JSON�ļ�·����������ʾ���ı�����
                MessageBox.Show("��ѡ���JSON�ļ�·����: " + selectedJsonFilePath);

                // ���������Ӵ�������ȡ�ʹ���JSON�ļ�
                // ���磺
                string jsonContent = System.IO.File.ReadAllText(selectedJsonFilePath);
                this.jsonSource = JObject.Parse(jsonContent);


             

            
            }
        }

        private void buttonSelectTarget_Click(object sender, EventArgs e)
        {
            // ����OpenFileDialogʵ��
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // �����ļ�����������ֻ����ѡ��JSON�ļ�
            openFileDialog.Filter = "JSON�ļ� (*.json)|*.json";

            // ���öԻ������
            openFileDialog.Title = "ѡ��JSON�ļ�";

            // ��ʾOpenFileDialog
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // ��ȡ�û�ѡ���JSON�ļ�·��
                string selectedJsonFilePath = openFileDialog.FileName;

                // ����JSON�ļ�·����������ʾ���ı�����
                MessageBox.Show("��ѡ���JSON�ļ�·����: " + selectedJsonFilePath);

                // ���������Ӵ�������ȡ�ʹ���JSON�ļ�
                // ���磺
                string jsonContent = File.ReadAllText(selectedJsonFilePath);
              
                // ָ��Ҫ��ȡ��Key

                jsonTarget = JObject.Parse(jsonContent);

             
            }
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            if (jsonSource == null || jsonTarget == null)
            {
                MessageBox.Show("����ѡ������JSON�ļ���");
                return;
            }
           
            // ����б�
            listBoxCommonKeys.Items.Clear();


            // ָ��Ҫ���˵���Key����
            string[] keysToFilter = new string[] { "name", "version", "scripts", "husky" };
            // �ݹ��滻����
            ReplaceSubItems(jsonSource, jsonTarget, keysToFilter);

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON�ļ� (*.json)|*.json",
                Title = "����ϲ����JSON�ļ�",
                FileName = "merged.json" // Ĭ���ļ���
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputFilePath = saveFileDialog.FileName;
                File.WriteAllText(outputFilePath, jsonSource.ToString(Formatting.Indented));
                MessageBox.Show("JSON�ļ��ѳɹ����浽: " + outputFilePath);
            }
        }
        private void ReplaceSubItems(JObject source, JObject target, string[] keysToFilter)
        {
            foreach (var item in source.Children<JProperty>())
            {
                string key = item.Name;
                JToken targetToken;

                // ����Ƿ���Ҫ���˵����Key
                if (Array.IndexOf(keysToFilter, key) >= 0)
                {
                    continue; // �������Key
                }

                if (target.TryGetValue(key, out targetToken))
                {
                    JProperty property = item;
                    if (property.Value.Type == JTokenType.Object && targetToken.Type == JTokenType.Object)
                    {
                        // ���target�д��ڶ�Ӧ�ļ������Ҷ�Ӧ��ֵ�Ƕ�����ݹ��滻����
                        ReplaceSubItems((JObject)property.Value, (JObject)targetToken, keysToFilter);
                    }
                    else
                    {
                        // ���target�е�ֵ���Ƕ������source�е�ֵ���Ƕ������滻source�е�ֵ
                        source[key] = targetToken.DeepClone(); // ʹ��DeepClone()ȷ��ֵ����ȷ����

                        // ���������ͬ��Key����ӵ�ListBox��
                        listBoxCommonKeys.Items.Add(key);
                    }
                }
            }
        }
        
    }
}