using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Flight
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            this.result.Text = "";
            if (int.Parse((number.Text)) < 0 || number.Text == "" || A.Text == "" || B.Text == "" || C.Text == "")
            {
                this.result.Text = "存在错误的输入";
            }

            else
            {
                string airline = lines.SelectedItem as string;
                if (airline == "国内")
                {
                    if (int.Parse((number.Text)) == 0)
                    {
                        this.result.Text = "未携带行李";
                    }
                    else
                    {
                        string[] w = weight.Text.Split(' ');
                        string[] a = A.Text.Split(' ');
                        string[] b = B.Text.Split(' ');
                        string[] c = C.Text.Split(' ');

                        //this.result.Text = w.Length.ToString();
                        for (int i = 0; i < int.Parse((number.Text)); i++)
                        {
                            //this.result.Text += (" "+w[i]);
                            int intw = int.Parse(w[i]);
                            int inta = int.Parse(a[i]);
                            int intb = int.Parse(b[i]);
                            int intc = int.Parse(c[i]);
                            if (intw > 50 || inta > 100 || intb > 40 || intc > 60 || intw < 0 || inta < 0 || intb < 0 || intc < 0)
                            {
                                if(intw > 50 || inta > 100 || intb > 40 || intc > 60)
                                    this.result.Text += ("第" + (i + 1) + "件行李超重/超尺寸，无法办理托运\n");
                                if(intw < 0 || inta < 0 || intb < 0 || intc < 0)
                                    this.result.Text += ("存在错误的输入\n");
                            }
                            else
                            {
                                string t = types.SelectedItem as string;
                                string vip = special.SelectedItem as string;
                                if (t == "头等舱（成人、儿童、占座婴儿）")
                                {
                                    int maxw = 40;
                                    if (vip == "南航明珠金卡会员、天合联盟超级精英")
                                    {
                                        maxw += 20;
                                    }
                                    if (vip == "南航明珠银卡会员、天合联盟精英")
                                    {
                                        maxw += 10;
                                    }
                                    
                                    if (intw <= maxw)
                                    {
                                        this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                    }
                                    else
                                    {
                                        this.result.Text +=
                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要支付当日经济舱票价的" +
                                             (intw - maxw) * 1.5 + "%\n");
                                    }
                                }
                                else
                                {
                                    if (t == "公务舱（成人、儿童、占座婴儿）")
                                    {
                                        int maxw = 30;
                                        if (vip == "南航明珠金卡会员、天合联盟超级精英")
                                        {
                                            maxw += 20;
                                        }
                                        if (vip == "南航明珠银卡会员、天合联盟精英")
                                        {
                                            maxw += 10;
                                        }

                                        if (intw <= maxw)
                                        {
                                            this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                        }
                                        else
                                        {
                                            this.result.Text +=
                                                ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要支付当日经济舱票价的" +
                                                 (intw - maxw) * 1.5 + "%\n");
                                        }
                                    }
                                    else
                                    {
                                        if (t == "经济舱（成人、儿童、占座婴儿）" || t == "明珠经济舱（成人、儿童、占座婴儿）")
                                        {
                                            int maxw = 20;
                                            if (vip == "南航明珠金卡会员、天合联盟超级精英")
                                            {
                                                maxw += 20;
                                            }
                                            if (vip == "南航明珠银卡会员、天合联盟精英")
                                            {
                                                maxw += 10;
                                            }
                                            if (intw <= maxw)
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                            }
                                            else
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要支付当日经济舱票价的" + (intw - maxw) * 1.5 + "%\n");
                                            }
                                        }
                                        else
                                        {
                                            if (t == "不占座婴儿（任意客舱）")
                                            {
                                                if (intw <= 10)
                                                {
                                                    this.result.Text += ("该婴儿行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    this.result.Text += ("婴儿行李超重" + (intw - 10) + "kg，" + "办理托运需要支付当日经济舱票价的" + (intw - 10) * 1.5 + "%\n");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                if (airline == "日本、美洲、澳新、俄罗斯（包括欧洲和亚洲部分）、迪拜(不含兰州、乌鲁木齐)、新加坡始发至中国大陆")
                {
                    if (int.Parse((number.Text)) == 0)
                    {
                        this.result.Text = "未携带行李";
                    }
                    else
                    {
                        string[] w = weight.Text.Split(' ');
                        string[] a = A.Text.Split(' ');
                        string[] b = B.Text.Split(' ');
                        string[] c = C.Text.Split(' ');

                        //this.result.Text = w.Length.ToString();
                        for (int i = 0; i < int.Parse((number.Text)); i++)
                        {
                            //this.result.Text += (" "+w[i]);
                            int intw = int.Parse(w[i]);
                            int inta = int.Parse(a[i]);
                            int intb = int.Parse(b[i]);
                            int intc = int.Parse(c[i]);
                            int length = inta + intb + intc;


                            if (length >158 && length <= 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超尺寸，需要额外支付1000元人民币的托运费用 \n");
                            }

                            if (((Bool.SelectedItem as string == "是" && intw > 45) || (Bool.SelectedItem as string == "否" && intw > 32)) || length > 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超重/超尺寸，无法办理托运\n");
                            }
                            else
                            {
                                string t = types.SelectedItem as string;
                                string vip = special.SelectedItem as string;
                
                                if (t == "头等舱（成人、儿童、占座婴儿）")
                                {
                                    int maxw = 32, maxnum = 3;
                                    if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                    {
                                        maxnum = 4;
                                    }

                                    if (intw <= maxw && i <= maxnum)
                                    {
                                        this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                    }
                                    else
                                    {
                                        if(intw > maxw)
                                        this.result.Text +=
                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                        if (i > maxnum)
                                        {
                                            if (i - maxnum == 1)
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                            else
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (t == "公务舱（成人、儿童、占座婴儿）")
                                    {
                                        int maxw = 32, maxnum = 2;
                                        if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                        {
                                            maxnum = 3;
                                        }

                                        if (intw <= maxw && i <= maxnum)
                                        {
                                            this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                        }
                                        else
                                        {
                                            if (intw > maxw)
                                                this.result.Text +=
                                                    ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                            if (i > maxnum)
                                            {
                                                if (i - maxnum == 1)
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                                else
                                                {
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (t == "经济舱（成人、儿童、占座婴儿）" || t == "明珠经济舱（成人、儿童、占座婴儿）")
                                        {
                                            int maxw = 23, maxnum = 2;
                                            if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                            {
                                                maxnum = 3;
                                            }

                                            if (intw <= maxw && i <= maxnum)
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                            }
                                            else
                                            {
                                                if (intw > maxw)
                                                {
                                                    if (intw <= 32)
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付1000元人民币%\n");
                                                    }
                                                    else
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                    }
                                                }

                                                if (i > maxnum)
                                                {
                                                    if (i - maxnum == 1)
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                                    else
                                                    {
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (t == "不占座婴儿（任意客舱）")
                                            {
                                                if (intw <= 10 && int.Parse(number.Text) <= 1 && length <=115)
                                                {
                                                    this.result.Text += ("该婴儿行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    this.result.Text += ("婴儿行李超重/数量超出限制/超出尺寸限制，不允许办理托运\n");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                if (airline == "迪拜(与兰州、乌鲁木齐之间)")
                {
                    if (int.Parse((number.Text)) == 0)
                    {
                        this.result.Text = "未携带行李";
                    }
                    else
                    {
                        string[] w = weight.Text.Split(' ');
                        string[] a = A.Text.Split(' ');
                        string[] b = B.Text.Split(' ');
                        string[] c = C.Text.Split(' ');

                        //this.result.Text = w.Length.ToString();
                        for (int i = 0; i < int.Parse((number.Text)); i++)
                        {
                            //this.result.Text += (" "+w[i]);
                            int intw = int.Parse(w[i]);
                            int inta = int.Parse(a[i]);
                            int intb = int.Parse(b[i]);
                            int intc = int.Parse(c[i]);
                            int length = inta + intb + intc;

                            if (length > 158 && length <= 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超尺寸，需要额外支付1000元人民币的托运费用 \n");
                            }

                            if (((Bool.SelectedItem as string == "是" && intw > 45) || (Bool.SelectedItem as string == "否" && intw > 32)) || length > 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超重/超尺寸，无法办理托运\n");
                            }
                            else
                            {
                                string t = types.SelectedItem as string;
                                string vip = special.SelectedItem as string;

                                if (t == "头等舱（成人、儿童、占座婴儿）")
                                {
                                    int maxw = 32, maxnum = 3;
                                    if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                    {
                                        maxnum = 4;
                                    }

                                    if (intw <= maxw && i <= maxnum)
                                    {
                                        this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                    }
                                    else
                                    {
                                        if (intw > maxw)
                                            this.result.Text +=
                                                ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                        if (i > maxnum)
                                        {
                                            if (i - maxnum == 1)
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                            else
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (t == "公务舱（成人、儿童、占座婴儿）")
                                    {
                                        int maxw = 32, maxnum = 2;
                                        if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                        {
                                            maxnum = 3;
                                        }

                                        if (intw <= maxw && i <= maxnum)
                                        {
                                            this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                        }
                                        else
                                        {
                                            if (intw > maxw)
                                                this.result.Text +=
                                                    ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                            if (i > maxnum)
                                            {
                                                if (i - maxnum == 1)
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                                else
                                                {
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (t == "经济舱（成人、儿童、占座婴儿）")
                                        {
                                            int maxw = 23, maxnum = 1;
                                            if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                            {
                                                maxnum = 2;
                                            }

                                            if (intw <= maxw && i <= maxnum)
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                            }
                                            else
                                            {
                                                if (intw > maxw)
                                                {
                                                    if (intw <= 32)
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付1000元人民币%\n");
                                                    }
                                                    else
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                    }
                                                }

                                                if (i > maxnum)
                                                {
                                                    if (i - maxnum == 1)
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                                    else
                                                    {
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (t == "明珠经济舱（成人、儿童、占座婴儿）")
                                            {
                                                int maxw = 32, maxnum = 1;
                                                if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                                {
                                                    maxnum = 2;
                                                }

                                                if (intw <= maxw && i <= maxnum)
                                                {
                                                    this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    if (intw > maxw)
                                                    {
                                                        this.result.Text += ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                    }

                                                    if (i > maxnum)
                                                    {
                                                        if (i - maxnum == 1)
                                                            this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                                        else
                                                        {
                                                            this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                                        }
                                                    }
                                                }
                                            }

                                            if (t == "不占座婴儿（任意客舱）")
                                            {
                                                if (intw <= 10 && int.Parse(number.Text) <= 1 && length <= 115)
                                                {
                                                    this.result.Text += ("该婴儿行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    this.result.Text += ("婴儿行李超重/数量超出限制/超出尺寸限制，不允许办理托运\n");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                if (airline == "中西亚航线")
                {
                    if (int.Parse((number.Text)) == 0)
                    {
                        this.result.Text = "未携带行李";
                    }
                    else
                    {
                        string[] w = weight.Text.Split(' ');
                        string[] a = A.Text.Split(' ');
                        string[] b = B.Text.Split(' ');
                        string[] c = C.Text.Split(' ');

                        //this.result.Text = w.Length.ToString();
                        for (int i = 0; i < int.Parse((number.Text)); i++)
                        {
                            //this.result.Text += (" "+w[i]);
                            int intw = int.Parse(w[i]);
                            int inta = int.Parse(a[i]);
                            int intb = int.Parse(b[i]);
                            int intc = int.Parse(c[i]);
                            int length = inta + intb + intc;

                            if (length > 158 && length <= 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超尺寸，需要额外支付1000元人民币的托运费用 \n");
                            } 

                            if (((Bool.SelectedItem as string == "是" && intw > 45) || (Bool.SelectedItem as string == "否" && intw > 32)) || length > 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超重/超尺寸，无法办理托运\n");
                            }
                            else
                            {
                                string t = types.SelectedItem as string;
                                string vip = special.SelectedItem as string;

                                if (t == "头等舱（成人、儿童、占座婴儿）")
                                {
                                    int maxw = 32, maxnum = 3;
                                    if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                    {
                                        maxnum = 4;
                                    }

                                    if (intw <= maxw && i <= maxnum)
                                    {
                                        this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                    }
                                    else
                                    {
                                        if (intw > maxw)
                                            this.result.Text +=
                                                ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                        if (i > maxnum)
                                        {
                                            if (i - maxnum == 1)
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                            else
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (t == "公务舱（成人、儿童、占座婴儿）")
                                    {
                                        int maxw = 32, maxnum = 2;
                                        if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                        {
                                            maxnum = 3;
                                        }

                                        if (intw <= maxw && i <= maxnum)
                                        {
                                            this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                        }
                                        else
                                        {
                                            if (intw > maxw)
                                                this.result.Text +=
                                                    ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                            if (i > maxnum)
                                            {
                                                if (i - maxnum == 1)
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                                else
                                                {
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (t == "经济舱（成人、儿童、占座婴儿） || 明珠经济舱（成人、儿童、占座婴儿）")
                                        {
                                            int maxw = 23, maxnum = 2;
                                            if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                            {
                                                maxnum = 3;
                                            }

                                            if (intw <= maxw && i <= maxnum)
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                            }
                                            else
                                            {
                                                if (intw > maxw)
                                                {
                                                    if (intw <= 32)
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付1000元人民币%\n");
                                                    }
                                                    else
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                    }
                                                }

                                                if (i > maxnum)
                                                {
                                                    if (i - maxnum == 1)
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                                    else
                                                    {
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (t == "不占座婴儿（任意客舱）")
                                            {
                                                if (intw <= 10 && int.Parse(number.Text) <= 1 && length <= 115)
                                                {
                                                    this.result.Text += ("该婴儿行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    this.result.Text += ("婴儿行李超重/数量超出限制/超出尺寸限制，不允许办理托运\n");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
                
                if (airline == "涉及内罗毕的航程（不含毛里求斯）")
                {
                    if (int.Parse((number.Text)) == 0)
                    {
                        this.result.Text = "未携带行李";
                    }
                    else
                    {
                        string[] w = weight.Text.Split(' ');
                        string[] a = A.Text.Split(' ');
                        string[] b = B.Text.Split(' ');
                        string[] c = C.Text.Split(' ');

                        //this.result.Text = w.Length.ToString();
                        for (int i = 0; i < int.Parse((number.Text)); i++)
                        {
                            //this.result.Text += (" "+w[i]);
                            int intw = int.Parse(w[i]);
                            int inta = int.Parse(a[i]);
                            int intb = int.Parse(b[i]);
                            int intc = int.Parse(c[i]);
                            int length = inta + intb + intc;

                            if (length > 158 && length <= 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超尺寸，需要额外支付1000元人民币的托运费用 \n");
                            }

                            if (((Bool.SelectedItem as string == "是" && intw > 45) || (Bool.SelectedItem as string == "否" && intw > 32)) || length > 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超重/超尺寸，无法办理托运\n");
                            }
                            else
                            {
                                string t = types.SelectedItem as string;
                                string vip = special.SelectedItem as string;

                                if (t == "头等舱（成人、儿童、占座婴儿）")
                                {
                                    int maxw = 32, maxnum = 3;
                                    if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                    {
                                        maxnum = 4;
                                    }

                                    if (intw <= maxw && i <= maxnum)
                                    {
                                        this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                    }
                                    else
                                    {
                                        if (intw > maxw)
                                            this.result.Text +=
                                                ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                        if (i > maxnum)
                                        {
                                            if (i - maxnum == 1)
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                            else
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (t == "公务舱（成人、儿童、占座婴儿）")
                                    {
                                        int maxw = 32, maxnum = 2;
                                        if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                        {
                                            maxnum = 3;
                                        }

                                        if (intw <= maxw && i <= maxnum)
                                        {
                                            this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                        }
                                        else
                                        {
                                            if (intw > maxw)
                                                this.result.Text +=
                                                    ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                            if (i > maxnum)
                                            {
                                                if (i - maxnum == 1)
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                                else
                                                {
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (t == "经济舱（成人、儿童、占座婴儿）" || t == "明珠经济舱（成人、儿童、占座婴儿）")
                                        {
                                            int maxw = 23, maxnum = 2;
                                            if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                            {
                                                maxnum = 3;
                                            }

                                            if (intw <= maxw && i <= maxnum)
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                            }
                                            else
                                            {
                                                if (intw > maxw)
                                                {
                                                    if (intw <= 32)
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付2000元人民币%\n");
                                                    }
                                                    else
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                    }
                                                }

                                                if (i > maxnum)
                                                {
                                                    if (i - maxnum == 1)
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1000元\n");
                                                    else
                                                    {
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付2000元\n");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (t == "不占座婴儿（任意客舱）")
                                            {
                                                if (intw <= 10 && int.Parse(number.Text) <= 1 && length <= 115)
                                                {
                                                    this.result.Text += ("该婴儿行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    this.result.Text += ("婴儿行李超重/数量超出限制/超出尺寸限制，不允许办理托运\n");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                if (airline == "其他航线（含毛里求斯，不含韩国始发与中国间航程）")
                {
                    if (int.Parse((number.Text)) == 0)
                    {
                        this.result.Text = "未携带行李";
                    }
                    else
                    {
                        string[] w = weight.Text.Split(' ');
                        string[] a = A.Text.Split(' ');
                        string[] b = B.Text.Split(' ');
                        string[] c = C.Text.Split(' ');

                        //this.result.Text = w.Length.ToString();
                        for (int i = 0; i < int.Parse((number.Text)); i++)
                        {
                            //this.result.Text += (" "+w[i]);
                            int intw = int.Parse(w[i]);
                            int inta = int.Parse(a[i]);
                            int intb = int.Parse(b[i]);
                            int intc = int.Parse(c[i]);
                            int length = inta + intb + intc;

                            if (length > 158 && length <= 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超尺寸，需要额外支付1000元人民币的托运费用 \n");
                            }

                            if (((Bool.SelectedItem as string == "是" && intw > 45) || (Bool.SelectedItem as string == "否" && intw > 32)) || length > 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超重/超尺寸，无法办理托运\n");
                            }
                            else
                            {
                                string t = types.SelectedItem as string;
                                string vip = special.SelectedItem as string;

                                if (t == "头等舱（成人、儿童、占座婴儿）")
                                {
                                    int maxw = 32, maxnum = 3;
                                    if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                    {
                                        maxnum = 4;
                                    }

                                    if (intw <= maxw && i <= maxnum)
                                    {
                                        this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                    }
                                    else
                                    {
                                        if (intw > maxw)
                                            this.result.Text +=
                                                ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                        if (i > maxnum)
                                        {
                                            if (i - maxnum == 1)
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                            else
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (t == "公务舱（成人、儿童、占座婴儿）")
                                    {
                                        int maxw = 23, maxnum = 3;
                                        if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                        {
                                            maxnum = 4;
                                        }

                                        if (intw <= maxw && i <= maxnum)
                                        {
                                            this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                        }
                                        else
                                        {
                                            if (intw > maxw)
                                            {
                                                if (intw <= 32)
                                                {
                                                    this.result.Text +=
                                                        ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付1000元人民币%\n");
                                                }
                                                else
                                                {
                                                    this.result.Text +=
                                                        ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                }
                                            }
 
                                            if (i > maxnum)
                                            {
                                                if (i - maxnum == 1)
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                                else
                                                {
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (t == "经济舱（成人、儿童、占座婴儿）")
                                        {
                                            int maxw = 23, maxnum = 1;
                                            if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                            {
                                                maxnum = 2;
                                            }

                                            if (intw <= maxw && i <= maxnum)
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                            }
                                            else
                                            {
                                                if (intw > maxw)
                                                {
                                                    if (intw <= 32)
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付1000元人民币%\n");
                                                    }
                                                    else
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                    }
                                                }

                                                if (i > maxnum)
                                                {
                                                    if (i - maxnum == 1)
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                                    else
                                                    {
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (t == "明珠经济舱（成人、儿童、占座婴儿）")
                                            {
                                                int maxw = 23, maxnum = 2;
                                                if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                                {
                                                    maxnum = 3;
                                                }

                                                if (intw <= maxw && i <= maxnum)
                                                {
                                                    this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    if (intw > maxw)
                                                    {
                                                        if (intw <= 32)
                                                        {
                                                            this.result.Text +=
                                                                ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付1000元人民币%\n");
                                                        }
                                                        else
                                                        {
                                                            this.result.Text +=
                                                                ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                        }
                                                    }

                                                    if (i > maxnum)
                                                    {
                                                        if (i - maxnum == 1)
                                                            this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                                        else
                                                        {
                                                            this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                                        }
                                                    }
                                                }
                                            }

                                            if (t == "不占座婴儿（任意客舱）")
                                            {
                                                if (intw <= 10 && int.Parse(number.Text) <= 1 && length <= 115)
                                                {
                                                    this.result.Text += ("该婴儿行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    this.result.Text += ("婴儿行李超重/数量超出限制/超出尺寸限制，不允许办理托运\n");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                if (airline == "韩国始发与中国间航程")
                {
                    if (int.Parse((number.Text)) == 0)
                    {
                        this.result.Text = "未携带行李";
                    }
                    else
                    {
                        string[] w = weight.Text.Split(' ');
                        string[] a = A.Text.Split(' ');
                        string[] b = B.Text.Split(' ');
                        string[] c = C.Text.Split(' ');

                        //this.result.Text = w.Length.ToString();
                        for (int i = 0; i < int.Parse((number.Text)); i++)
                        {
                            //this.result.Text += (" "+w[i]);
                            int intw = int.Parse(w[i]);
                            int inta = int.Parse(a[i]);
                            int intb = int.Parse(b[i]);
                            int intc = int.Parse(c[i]);
                            int length = inta + intb + intc;

                            if (length > 158 && length <= 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超尺寸，需要额外支付1000元人民币的托运费用 \n");
                            }

                            if (((Bool.SelectedItem as string == "是" && intw > 45) || (Bool.SelectedItem as string == "否" && intw > 32)) || length > 300)
                            {
                                this.result.Text += ("第" + (i + 1) + "件行李超重/超尺寸，无法办理托运\n");
                            }
                            else
                            {
                                string t = types.SelectedItem as string;
                                string vip = special.SelectedItem as string;

                                if (t == "头等舱（成人、儿童、占座婴儿）")
                                {
                                    int maxw = 32, maxnum = 3;
                                    if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                    {
                                        maxnum = 4;
                                    }

                                    if (intw <= maxw && i <= maxnum)
                                    {
                                        this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                    }
                                    else
                                    {
                                        if (intw > maxw)
                                            this.result.Text +=
                                                ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                        if (i > maxnum)
                                        {
                                            if (i - maxnum == 1)
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                            else
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (t == "公务舱（成人、儿童、占座婴儿）")
                                    {
                                        int maxw = 32, maxnum = 2;
                                        if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                        {
                                            maxnum = 3;
                                        }

                                        if (intw <= maxw && i <= maxnum)
                                        {
                                            this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                        }
                                        else
                                        {
                                            if (intw > maxw)
                                            {
                                                this.result.Text +=
                                                        ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                            }

                                            if (i > maxnum)
                                            {
                                                if (i - maxnum == 1)
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                                else
                                                {
                                                    this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (t == "经济舱（成人、儿童、占座婴儿）")
                                        {
                                            int maxw = 23, maxnum = 1;
                                            if (vip == "南航明珠金卡会员、天合联盟超级精英" || vip == "南航明珠银卡会员、天合联盟精英" || vip == "留学生、劳务、海员")
                                            {
                                                maxnum = 2;
                                            }

                                            if (intw <= maxw && i <= maxnum)
                                            {
                                                this.result.Text += ("第" + (i + 1) + "件行李办理托运时无需再额外付费\n");
                                            }
                                            else
                                            {
                                                if (intw > maxw)
                                                {
                                                    if (intw <= 32)
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付1000元人民币%\n");
                                                    }
                                                    else
                                                    {
                                                        this.result.Text +=
                                                            ("第" + (i + 1) + "件行李超重" + (intw - maxw) + "kg，" + "办理托运需要额外支付3000元人民币%\n");
                                                    }
                                                }

                                                if (i > maxnum)
                                                {
                                                    if (i - maxnum == 1)
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付450元\n");
                                                    else
                                                    {
                                                        this.result.Text += ("第" + (i + 1) + "件行李超出件数限制，办理托运需要为该件支付1300元\n");
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (t == "明珠经济舱（成人、儿童、占座婴儿）")
                                            {
                                                this.result.Text = "该航线无此客舱，你是否想选择经济舱？";
                                            }

                                            if (t == "不占座婴儿（任意客舱）")
                                            {
                                                if (intw <= 10 && int.Parse(number.Text) <= 1 && length <= 115)
                                                {
                                                    this.result.Text += ("该婴儿行李办理托运时无需再额外付费\n");
                                                }
                                                else
                                                {
                                                    this.result.Text += ("婴儿行李超重/数量超出限制/超出尺寸限制，不允许办理托运\n");
                                                }
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }


        private void Weight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
