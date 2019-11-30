using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System.IO;

namespace 霞山妇幼短信
{
    public partial class FrmSendMassage : Form
    {
        string str_title = "";
        public static int i_sendcount = 0;
        public static int i_rowcount = 0;
        public FrmSendMassage(string str_title)
        {
            InitializeComponent();
            this.str_title = str_title;
            this.Text = str_title+"工资短信发送";
            label2.Text= str_title + "工资短信发送";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ImportDV import = new ImportDV();
            import.btnImpot_Click(dataGridView1, textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string str_name = "";
                int i_success = 0;
                int i_fail = 0;
                i_sendcount =0;
                i_rowcount = dataGridView1.Rows.Count;
                string str_return_message = "";
                AsyncWaitControl a = new AsyncWaitControl();
                this.AsyncWaitDo(delegate
                {
                    if (str_title == "基本")
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            str_return_message = SendMessageByJiben(dataGridView1.Rows[i]);
                            addLog(dataGridView1.Rows[i].Cells["姓名"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["电话号码"].Value.ToString() + "," + str_return_message);
                            if (str_return_message != "OK")
                            {
                                str_name = str_name + dataGridView1.Rows[i].Cells["姓名"].Value.ToString();
                                i_fail++;


                            }
                            else
                            {
                                i_success++;
                            }

                            i_sendcount++;
                        }
                    }
                    else if (str_title == "绩效")
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            str_return_message = SendMessageByJixiao(dataGridView1.Rows[i]);
                            addLog(dataGridView1.Rows[i].Cells["姓名"].Value.ToString() + "," + dataGridView1.Rows[i].Cells["电话号码"].Value.ToString() + "," + str_return_message);
                            if (str_return_message != "OK")
                            {
                                str_name = str_name + dataGridView1.Rows[i].Cells["姓名"].Value.ToString();
                                i_fail++;

                            }
                            else
                            {
                                i_success++;
                            }
                            i_sendcount++;


                        }
                    }

                },
                    delegate
                    {
                        MessageBox.Show("发送完成！成功：" + i_success.ToString() + "条,失败：" + i_fail.ToString() + "条。详情请查看日志！");

                    });


            }
            catch (Exception ex)
            {
                MessageBox.Show("表格格式不正确！");
            }
        }
        public string SendMessageByJixiao(DataGridViewRow dgvr)
        {
            String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            String accessKeyId = "LTAI4FugPzRHJVse3oN6RNKn";//你的accessKeyId，参考本文档步骤2
            String accessKeySecret = "ONYrai4gO8CJ3wIrF0ZGyPJw5iOJ0r";//你的accessKeySecret，参考本文档步骤2
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);
            // SingleSendSmsRequest request = new SingleSendSmsRequest();
            //初始化ascClient,暂时不支持多region（请勿修改）
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式，发送国际/港澳台消息时，接收号码格式为00+国际区号+号码，如“0085200000000”
                request.PhoneNumbers = dgvr.Cells["电话号码"].Value.ToString();
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "湛江市霞山妇幼保健院";
                //必填:短信模板-可在短信控制台中找到，发送国际/港澳台消息时，请使用国际/港澳台短信模版
                request.TemplateCode = "SMS_178760067";
                request.TemplateParam = "{\"xingming\":\"" + dgvr.Cells["姓名"].Value.ToString() + "\""
                    + ",\"yuefen\":\"" + dgvr.Cells["月份"].Value.ToString() + "\""
                    + ",\"yingfajixiao\":\"" + dgvr.Cells["应发绩效"].Value.ToString() + "元\""
                    + ",\"jibenjixiao\":\"" + dgvr.Cells["基本绩效"].Value.ToString() + "元\""
                    + ",\"jiaban\":\"" + dgvr.Cells["加班"].Value.ToString() + "元\""
                    + ",\"yeban\":\"" + dgvr.Cells["夜班"].Value.ToString() + "元\""
                    + ",\"qitajixiao\":\"" + dgvr.Cells["其他绩效"].Value.ToString() + "元\""
                    + ",\"zhufangbutie\":\"" + dgvr.Cells["住房补贴"].Value.ToString() + "元\""
                    + ",\"yingkoujixiao\":\"" + dgvr.Cells["应扣绩效"].Value.ToString() + "元\""
                    + ",\"gerensuodeshui\":\"" + dgvr.Cells["个人所得税"].Value.ToString() + "元\""
                    + ",\"zhiyenianjin\":\"" + dgvr.Cells["职业年金"].Value.ToString() + "元\""
                    + ",\"kouqita\":\"" + dgvr.Cells["扣其他"].Value.ToString() + "元\""
                    + ",\"shifajixiao\":\"" + dgvr.Cells["实发绩效"].Value.ToString() + "元\""
                    + "}";
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                // System.Console.WriteLine(sendSmsResponse.Message);
                return sendSmsResponse.Message;
                // MessageBox.Show(sendSmsResponse.Message);
            }
            catch (ServerException ex)
            {
                return ex.Message;
                //System.Console.WriteLine("Hello World!");
            }
            catch (ClientException ex)
            {
                return ex.Message;

            }
        }
        public string SendMessageByJiben(DataGridViewRow dgvr)
        {
            String product = "Dysmsapi";//短信API产品名称（短信产品名固定，无需修改）
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名（接口地址固定，无需修改）
            String accessKeyId = "LTAI4FugPzRHJVse3oN6RNKn";//你的accessKeyId，参考本文档步骤2
            String accessKeySecret = "ONYrai4gO8CJ3wIrF0ZGyPJw5iOJ0r";//你的accessKeySecret，参考本文档步骤2
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);
            //IAcsClient client = new DefaultAcsClient(profile);
            // SingleSendSmsRequest request = new SingleSendSmsRequest();
            //初始化ascClient,暂时不支持多region（请勿修改）
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式，发送国际/港澳台消息时，接收号码格式为00+国际区号+号码，如“0085200000000”
                request.PhoneNumbers = dgvr.Cells["电话号码"].Value.ToString();
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "湛江市霞山妇幼保健院";
                //必填:短信模板-可在短信控制台中找到，发送国际/港澳台消息时，请使用国际/港澳台短信模版
                request.TemplateCode = "SMS_178995528";
                //gongjijin-金额；feiyong-金额；shuidian-金额；wuguan-金额；kougonghui-金额；kouqita-金额；yingkougongzi-金额；shifagongzi-金额；
                request.TemplateParam = "{\"xingming\":\"" + dgvr.Cells["姓名"].Value.ToString() + "\""
                    + ",\"yuefen\":\"" + dgvr.Cells["月份"].Value.ToString() + "\""
                    + ",\"jibengongzi\":\"" + dgvr.Cells["基本工资"].Value.ToString() + "\""//因为模板中有“元”所以不需要有元字
                    + ",\"zhiwugangweijintie\":\"" + dgvr.Cells["职务岗位津贴"].Value.ToString() + "元\""
                    + ",\"huling\":\"" + dgvr.Cells["护龄"].Value.ToString() + "元\""
                    + ",\"zhufangbutie\":\"" + dgvr.Cells["住房补贴"].Value.ToString() + "元\""
                    + ",\"youxiu\":\"" + dgvr.Cells["优秀"].Value.ToString() + "元\""
                    + ",\"jisheng\":\"" + dgvr.Cells["计生"].Value.ToString() + "元\""
                    + ",\"bingshijia\":\"" + dgvr.Cells["病事假"].Value.ToString() + "元\""
                    + ",\"qita\":\"" + dgvr.Cells["其他"].Value.ToString() + "元\""
                    + ",\"bugongzi\":\"" + dgvr.Cells["补工资"].Value.ToString() + "元\""
                    + ",\"tuixiushebao\":\"" + dgvr.Cells["退休社保"].Value.ToString() + "元\""
                    + ",\"yingfagzi\":\"" + dgvr.Cells["应发工资"].Value.ToString() + "元\""
                    + ",\"shebao\":\"" + dgvr.Cells["社保"].Value.ToString() + "元\""
                     + ",\"gongjijin\":\"" + dgvr.Cells["公积金"].Value.ToString() + "元\""
                     + ",\"feiyong\":\"" + dgvr.Cells["费用"].Value.ToString() + "元\""
                     + ",\"shuidian\":\"" + dgvr.Cells["水电"].Value.ToString() + "元\""
                     + ",\"wuguan\":\"" + dgvr.Cells["物管"].Value.ToString() + "元\""
                     + ",\"kougonghui\":\"" + dgvr.Cells["扣工会"].Value.ToString() + "元\""
                     + ",\"kouqita\":\"" + dgvr.Cells["扣其他"].Value.ToString() + "元\""
                     + ",\"yingkougongzi\":\"" + dgvr.Cells["应扣工资"].Value.ToString() + "元\""
                     + ",\"shifagongzi\":\"" + dgvr.Cells["实发工资"].Value.ToString() + "元\""
                         + "}";

                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);
                // System.Console.WriteLine(sendSmsResponse.Message);
                return sendSmsResponse.Message;
                // MessageBox.Show(sendSmsResponse.Message);
            }
            catch (ServerException ex)
            {
                return ex.Message;
                //System.Console.WriteLine("Hello World!");
            }
            catch (ClientException ex)
            {
                return ex.Message;

            }
        }
        public void addLog(String str)
        {
            if (File.Exists(@".\log.txt"))
            {



                StreamWriter sw = new StreamWriter(@".\log.txt", true);
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(str);
                sw.Flush();
                sw.Close();

            }
            else
            {
                FileStream sf = new FileStream(@".\log.txt", FileMode.Create);
                sf.Close();
                addLog(str);
            }

        }
    }
}
