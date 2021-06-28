using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using PcapDotNet.Base;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Arp;
using PcapDotNet.Packets.Dns;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.Gre;
using PcapDotNet.Packets.Http;
using PcapDotNet.Packets.Icmp;
using PcapDotNet.Packets.Igmp;
using PcapDotNet.Packets.IpV4;
using PcapDotNet.Packets.IpV6;
using PcapDotNet.Packets.Transport;
using PcapDotNet.Core.Extensions;
using System.Runtime.InteropServices;

namespace agProgramlamaOdev
{
    public partial class Form1 : Form
    {
        static IList<LivePacketDevice> allDevices;
        static LivePacketDevice selectedDevice;
        static MacAddress sourceMAC;
        static MacAddress destinationMAC;
        static string sourceIP_str;
        static string destinationIP_str;
        static IpV4Address sourceIP, destinationIP;
        static bool selectedDeviceBool = false;
        private bool icmpErrorFlag = true;
        ushort icmpID = 1;
        ushort udpID = 100;
        ushort srcPort = 4050;
        ushort dstPort = 4025;
        private Thread icmpSend;
        private Thread icmpRecieve;
        private Thread udpSend;
        private Thread udpRecieve;
        private Thread udpRecievedMsgAdgAdd;
        Queue<Packet> queue = new Queue<Packet>();

        public Form1()
        {
            InitializeComponent();
            InitializeComponent2();
            DeviceListerer();

            msgToSendTB.Text = "Merhaba!";
            nUD1.Value = 192;
            nUD2.Value = 168;
            nUD3.Value = 1;
            nUD4.Value = 1;
            

            
            // getMacAddressTxtbox.Text = "Cihazınızın gateway mac adresi buraya gelmelidir";
            // eğer cihazınızın MAC adresini bilmiyor iseniz FF:FF:FF:FF:FF:FF mac adresini atayabilirsiniz
           
        }


        private void InitializeComponent2()
        {
            //numericUpDown'lardaki aşşağı yukarı sayı değiştiren oku gizlemek için gerekli kod.
            nUD1.Controls[0].Hide();
            nUD2.Controls[0].Hide();
            nUD3.Controls[0].Hide();
            nUD4.Controls[0].Hide();

            //multiThread Tanımları
            icmpSend = new Thread(icmpSender) { IsBackground = true };
            icmpRecieve = new Thread(icmpReciever) { IsBackground = true };
            udpSend = new Thread(udpSender) { IsBackground = true };
            udpRecieve = new Thread(udpReciever) { IsBackground = true };
            udpRecievedMsgAdgAdd = new Thread(udpRecievedMsgAdgAdder) { IsBackground = true };


            //dgv'de seçili cell olmamasını sağlayan kod.
            MsgDGV.ClearSelection();
            //gelen veya giden mesajların tek satıra sığmadığında sığmasını sağlayan kod.
            MsgDGV.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            MsgDGV.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
        }


        //--------------PANEL 1 releated 111111111111111111111-----------------------

        //deviceDVG'e cihaza bağlı ethernet arayüzlerini ekleyen kod.
        private void DeviceListerer()
        {
            try
            {
                allDevices = LivePacketDevice.AllLocalMachine;
                deviceDVG.ColumnCount = 1;
                for (int i = 0; i != allDevices.Count; ++i)
                {

                    LivePacketDevice device = allDevices[i];
                    string device_str = device.Description;
                    device_str = device_str.Substring(17);
                    device_str = device_str.Substring(0, device_str.Length - 15);

                    string deviceDesc = device.Name;
                    deviceDesc = deviceDesc.Substring(21);
                    deviceDesc = deviceDesc.Substring(0, deviceDesc.Length - 1);
                    device_str = device_str + " -- " + deviceDesc;

                    if (device.Description != null)
                        deviceDVG.Rows.Add(device_str);


                }

            }
            catch (Exception)
            {
                MessageBox.Show("Hiçbir Ethernet Bağlantısı cihazı bulunamadı. " +
                                 "Bağlantı ayarlarınızı kontrol ediniz!", "Dikkat",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);

            }

        }
        //ethernet arayüzü seçmek için çıkan butonlardan hangisine seçildiyse ona göre MAC adresini belirleyen kod.
        private void deviceDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                selectedDevice = allDevices[int.Parse(deviceDVG.CurrentCell.RowIndex.ToString())];
                try
                {
                    sourceMAC = selectedDevice.GetMacAddress();
                }
                catch (Exception)
                {
                    MessageBox.Show("Bağlantı hatası!\nCihazın internet erişimi koptu",
                                     "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Thread.Sleep(10000);
                }

                selectedDeviceBool = true;
            }
        }

        // devam et yazılı butona basılması durumu
        private void IPConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDeviceBool == false) throw new Exception("İletişime geçilecek Ethernet Arayüzü seçiniz.");
                else
                {
                    // source ip adresini kendi seçili internet ailesinin adresinden çekme
                    sourceIP_str = null;
                    foreach (DeviceAddress address in selectedDevice.Addresses)
                    {
                        if (address.Address.Family == SocketAddressFamily.Internet)
                            sourceIP_str = address.Address.ToString().Substring(9, address.Address.ToString().Length - 9);
                    }

                    sourceIP = new IpV4Address(sourceIP_str);
                    string dstMac_str = getMacAddressTxtbox.Text.Trim().Replace(":", "").Replace("-", "").Replace(".", "");
                    if (dstMac_str.Length != 12)
                    {
                        throw new FormatException();
                    }

                    destinationMAC = new MacAddress(macAdrChanger(dstMac_str));
                    sourcePingLbl.Text = sourceIP.ToString();
                    //numericUpDown controllerinin value'lerini stringe atayıp dest IP olarak ipv4 türünde atamak ve bu paneli gizlemek.
                    destinationIP_str = nUD1.Value + "." + nUD2.Value + "." + nUD3.Value + "." + nUD4.Value;
                    destinationIP = new IpV4Address(destinationIP_str);

                    panel1.SendToBack();
                    panel2ReleatedThings();

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Geçerli bir MAC adresi girdiğinizden emin olunuz!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Broadcast mac adresini belirtip hedef mac bilinmediği durumda hedef mac adres değiştiren buton
        private void macTxtBoxFiller_Click(object sender, EventArgs e)
        {
            getMacAddressTxtbox.Text = "FF:FF:FF:FF:FF:FF";
        }

        // gelen seperator olmayan string mac adresine seperator ekleyip geri döndüren func
        public static string macAdrChanger(string str)
        {

            StringBuilder builder = new StringBuilder();
            for (var index = 0; index < str.Length; index += 2)
            {
                builder.Append(str, index, 2);
                builder.Append(":");
            }

            return builder.ToString().Remove(17);
        }


        //--------------PANEL 2 releated 22222222222222222222222222222-----------------------
        private void panel2ReleatedThings()
        {

            PleaseWaitDGV.Invoke(new MethodInvoker(delegate
            {
                PleaseWaitDGV.Rows.Add(sourceIP + " IP adresi kaynak IP adresi olarak belirlendi.");
                PleaseWaitDGV.Rows.Add(sourceMAC + " MAC adresi kaynak MAC adresi olarak belirlendi.");
                PleaseWaitDGV.Rows.Add(destinationIP + " IP adresi hedef IP adresi olarak belirlendi.");
                PleaseWaitDGV.Rows.Add(destinationMAC + " MAC adresi ağa çıkış arayüzünün adresi olarak belirlendi.");
                PleaseWaitDGV.Rows.Add("Ping paketi hazırlandı ve göndeirldi.");
            }));
            if (!icmpSend.IsAlive)
            {
                icmpSend = new Thread(icmpSender) { IsBackground = true };
                icmpSend.Start();

            }

            icmpRecieve.Start();


        }
        private void icmpSender()
        {
            try
            {


                using (PacketCommunicator communicator = selectedDevice.Open(100, // name of the device
                                                                          PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                                                          1000)) // read timeout
                {
                    EthernetLayer ethernetLayer = new EthernetLayer
                    {
                        Source = sourceMAC,
                        Destination = destinationMAC
                    };
                    IpV4Layer ipV4Layer = new IpV4Layer
                    {
                        Source = sourceIP,
                        CurrentDestination = destinationIP,
                        Identification = icmpID,
                        Ttl = 128,
                    };

                    IcmpEchoLayer icmpLayer = new IcmpEchoLayer();
                    PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, icmpLayer);
                    icmpLayer.SequenceNumber = icmpID;
                    icmpLayer.Identifier = icmpID;
                    Packet packet = builder.Build(DateTime.Now);
                    communicator.SendPacket(packet);
                    icmpID++;
                    PleaseWaitDGV.Invoke(new MethodInvoker(delegate
                    {
                        PleaseWaitDGV.Rows.Add((icmpID - 1) + " identification numarası ile ping gönderildi.");
                    }));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı hatası!\nCihazın internet erişimi koptu",
                            "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);

            }
            icmpSend.Abort();
        }

        private void icmpReciever()
        {
            try
            {

                using (PacketCommunicator communicator =
                    selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                                // 65536 guarantees that the whole packet will be captured on all the link layers
                                        PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                        1000))                                  // read timeout
                {
                    using (BerkeleyPacketFilter filter = communicator.CreateFilter("icmp and ip and dst " + sourceIP.ToString()))
                    {
                        communicator.SetFilter(filter);
                    }
                    PleaseWaitDGV.Invoke(new MethodInvoker(delegate
                    {
                        PleaseWaitDGV.Rows.Add("Cevap Dinleniyor;");
                    }));
                    Packet packet;

                    int icmpCounter = 0;
                    do
                    {

                        PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out packet);

                        switch (result)
                        {

                            case PacketCommunicatorReceiveResult.Ok:
                                PleaseWaitDGV.Invoke(new MethodInvoker(delegate
                                {
                                    pictureBox1.Visible = false;
                                    PleaseWaitLbl.Text = "Bağlantı Başarılı";

                                    

                                    sourceMAC = new MacAddress(packet.Ethernet.Source.ToString());
                                    PleaseWaitDGV.Rows.Add(sourceMAC + " Mac addressi gateway adresi olarak değiştirildi.");
                                    PleaseWaitDGV.Rows.Add("Bağlantı kuruldu: " + packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff"));
                                    PleaseWaitDGV.Rows[PleaseWaitDGV.RowCount - 1].Cells[0].Style.ForeColor = Color.Red;
                                    PleaseWaitDGV.Rows.Add("Sohbet Başlatılıyor...");
                                }));

                                DialogResult dr = MessageBox.Show("Sohbet Başlatılıyor... Devam etmek ister misiniz?", "Devam?",
                                                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                                if (dr == DialogResult.OK)
                                {
                                    panel2.Invoke(new MethodInvoker(delegate
                                    {
                                        icmpErrorFlag = false;
                                        icmpRecieve.Abort();
                                        icmpSend.Abort();
                                        panel2.Hide();
                                        panel3Constructer();
                                    }));

                                }
                                else if (dr == DialogResult.Cancel)
                                {
                                    System.Environment.Exit(0);
                                }
                                break;
                            case PacketCommunicatorReceiveResult.Timeout:
                                Thread.Sleep(500);
                                if (icmpCounter < 4)
                                {
                                    PleaseWaitDGV.Invoke(new MethodInvoker(delegate
                                    {
                                        PleaseWaitDGV.Rows.Add("Timeout, Tekrar deneniyor.");
                                    }));

                                    //tekrar ping gönderme
                                    if (!icmpSend.IsAlive)
                                    {
                                        icmpSend = new Thread(icmpSender) { IsBackground = true };
                                        icmpSend.Start();
                                    }

                                    icmpCounter++;
                                }
                                else if (icmpCounter >= 4)
                                {
                                    MessageBox.Show("Belirtilen IP adresile ile iletişime geçilemedi. Sistem sonlanıyor.");
                                    System.Environment.Exit(0);
                                }
                                break;
                            default:
                                continue;
                        }


                    } while (true);
                }
            }
            catch (Exception)
            {
                if (icmpErrorFlag == true)
                    MessageBox.Show("Bağlantı hatası!\nCihazın internet erişimi koptu",
                                "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                icmpRecieve.Abort();

            }
        }
        private void PleaseWaitDGV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            PleaseWaitDGV.FirstDisplayedScrollingRowIndex = PleaseWaitDGV.RowCount - 1;
        }


        //--------------PANEL 3 releated 33333333333333333333333333333-----------------------


        //Mesaj gönderilmeye başlandığında yapılan işlemlerin kodu. karşı taraf için reverse olcak.
        private void panel3Constructer()
        {
            label5.Text = destinationIP.ToString();


            udpRecieve.Start();
            udpRecievedMsgAdgAdd.Start();

        }

        //--------------------- mesaj gönderme releated ---------------------------------

        private void MsgSendBtn_Click(object sender, EventArgs e)
        {
            if (msgToSendTB.Text.Length == 0)
            {
                MessageBox.Show("Göndermek istediğiniz metin en az 1 karakter içermelidir",
                    "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (msgToSendTB.Text.Length >= 1472)
            {
                MessageBox.Show("Göndermek istediğiniz metin \n1472 " +
                    "karakterden uzun olmamalıdır.\nSizin metininiz: " +
                    msgToSendTB.Text.Length + " karkater uzunluğunda",
                    "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (!udpSend.IsAlive)
                {
                    udpSend = new Thread(udpSender) { IsBackground = true };
                    udpSend.Start();

                }
                if (!udpRecieve.IsAlive)
                {
                    udpRecieve = new Thread(udpReciever) { IsBackground = true };
                    udpRecieve.Start();

                }
            }

        }

        private void udpSender()
        {
            try
            {

                if (selectedDevice == null) throw new Exception();
                using (PacketCommunicator communicator = selectedDevice.Open(100, // name of the device
                                                                           PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                                                           1000)) // read timeout
                {

                    Packet p = BuildUdpPacket();
                    communicator.SendPacket(p);
                    MsgDGV.Invoke(new MethodInvoker(delegate
                    {
                        MsgDGV.Rows.Add();
                        int rowCount = int.Parse(MsgDGV.RowCount.ToString()) - 1;
                        MsgDGV.Rows[rowCount].Cells[1].Value = msgToSendTB.Text.TrimEnd().TrimStart();
                        MsgDGV.Rows[rowCount].Cells[1].Style.BackColor = Color.LightSkyBlue;
                        MsgDGV.Rows[rowCount].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleRight;

                        MsgDGV.Rows[rowCount].Cells[0].Value = DateTime.Now.ToString("h:mm:ss tt");
                        MsgDGV.Rows[rowCount].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        MsgDGV.Rows[rowCount].Cells[0].Style.ForeColor = Color.Blue;
                        MsgDGV.Rows[rowCount].Cells[0].Style.BackColor = Color.FromArgb(192, 255, 192);

                        MsgDGV.ClearSelection();
                        MsgDGV.FirstDisplayedScrollingRowIndex = MsgDGV.RowCount - 1;
                    }));

                }

            }
            catch (Exception)
            {
                udpSend.Abort();
            }
            return;
        }
        private Packet BuildUdpPacket()
        {
            EthernetLayer ethernetLayer =
                new EthernetLayer
                {
                    Source = sourceMAC,
                    Destination = destinationMAC,
                    EtherType = EthernetType.None, 
                };

            IpV4Layer ipV4Layer =
                new IpV4Layer
                {
                    Source = sourceIP,
                    CurrentDestination = destinationIP,
                    Fragmentation = IpV4Fragmentation.None,
                    HeaderChecksum = null, 
                    Identification = udpID,
                    Options = IpV4Options.None,
                    Protocol = null,
                    Ttl = 100,
                    TypeOfService = 0,
                };

            UdpLayer udpLayer =
                new UdpLayer
                {
                    SourcePort = srcPort,
                    DestinationPort = dstPort,
                    Checksum = null, 
                    CalculateChecksumValue = true,
                };

            PayloadLayer payloadLayer =
                new PayloadLayer
                {
                    Data = new Datagram(Encoding.ASCII.GetBytes(msgToSendTB.Text.TrimEnd().TrimStart())),
                };

            udpID++;
            PacketBuilder builder = new PacketBuilder(ethernetLayer, ipV4Layer, udpLayer, payloadLayer);

            return builder.Build(DateTime.Now);
        }


        //--------------------- mesaj alma releated ---------------------------------
        private void udpReciever()
        {
            Thread.Sleep(100);
            try
            {
                using (PacketCommunicator communicator =
                selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))                                  // read timeout
                {

                    using (BerkeleyPacketFilter filter = communicator.CreateFilter("udp and ip and " +
                                                    "port " + dstPort + " and dst " + sourceIP.ToString()))
                    {
                        communicator.SetFilter(filter);
                    }
                    Packet packet;
                    do
                    {
                        PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out packet);
                        switch (result)
                        {
                            case PacketCommunicatorReceiveResult.Ok:
                                lock (queue)
                                {
                                    queue.Enqueue(packet);
                                    break;
                                }
                            default:
                                continue;
                        }
                    } while (true);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bağlantı hatası!\nCihazın internet erişimi koptu",
                            "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                udpRecieve.Abort();

            }
        }



        //gelen mesajı dgv'ye ekleme
        private void udpRecievedMsgAdgAdder()
        {
            while (true)
            {
                Packet p;
                if (queue.Count > 0)
                {
                    lock (queue)
                    {
                        p = queue.Dequeue();
                    }

                }
                else
                    continue;

                IpV4Datagram ip = p.Ethernet.IpV4;
                UdpDatagram udp = ip.Udp;

                if (udp.DestinationPort == dstPort)
                {
                    string donenMesaj;
                    string sonuc = udp.ToHexadecimalString();
                    donenMesaj = sonuc.Substring(16);

                    var sb = new StringBuilder();
                    for (var i = 0; i < donenMesaj.Length; i += 2)
                    {
                        var hexChar = donenMesaj.Substring(i, 2);
                        sb.Append((char)Convert.ToByte(hexChar, 16));
                    }

                    MsgDGV.Invoke(new MethodInvoker(delegate
                    {
                        MsgDGV.Rows.Add();
                        int rowCount = int.Parse(MsgDGV.RowCount.ToString()) - 1;
                        MsgDGV.Rows[rowCount].Cells[0].Value = sb.ToString();
                        MsgDGV.Rows[rowCount].Cells[0].Style.BackColor = Color.SpringGreen;

                        MsgDGV.Rows[rowCount].Cells[1].Value = DateTime.Now.ToString("h:mm:ss tt");
                        MsgDGV.Rows[rowCount].Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        MsgDGV.Rows[rowCount].Cells[1].Style.ForeColor = Color.MediumSeaGreen;
                        MsgDGV.Rows[rowCount].Cells[1].Style.BackColor = Color.FromArgb(192, 255, 192);

                        MsgDGV.ClearSelection();
                        MsgDGV.FirstDisplayedScrollingRowIndex = MsgDGV.RowCount - 1;
                    }));
                }
            }
        }



        //max karakter sınırına aşılmaması için karakter sayısına göre label'in içeriğini ve text rengini değiştirme
        private void MaxCharLbl_TextChanged(object sender, EventArgs e)
        {
            int msgToSendCharCount = msgToSendTB.Text.TrimEnd().Length;
            MaxCharLbl.Text = msgToSendCharCount + " - 1472";
            if (msgToSendCharCount == 0)
            {
                MaxCharLbl.ForeColor = Color.Black;
            }
            else if (msgToSendCharCount > 1 && msgToSendCharCount <= 999)
            {
                MaxCharLbl.ForeColor = Color.Green;
            }
            else if (msgToSendCharCount > 100 && msgToSendCharCount <= 1399)
            {
                MaxCharLbl.ForeColor = Color.Gold;
            }
            else if (msgToSendCharCount > 1400 && msgToSendCharCount <= 1471)
            {
                MaxCharLbl.ForeColor = Color.Red;
            }
            else if (msgToSendCharCount > 1471)
            {
                MaxCharLbl.ForeColor = Color.DarkRed;
            }
        }


        //safe close
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (icmpSend.IsAlive)
            {
                icmpSend.Abort();
            }

            if (icmpRecieve.IsAlive)
            {
                icmpRecieve.Abort();
            }

            if (udpSend.IsAlive)
            {
                udpSend.Abort();
            }

            if (udpRecieve.IsAlive)
            {
                udpRecieve.Abort();
            }

            if (udpRecievedMsgAdgAdd.IsAlive)
            {
                udpRecievedMsgAdgAdd.Abort();
            }
        }
    }
}
