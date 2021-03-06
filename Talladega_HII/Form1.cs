﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Text;

namespace Talladega_HII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNode xmlnode;
            FileStream fs = new FileStream("tree.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.ChildNodes[1];
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
            TreeNode tNode;
            tNode = treeView1.Nodes[0];
            AddNode(xmlnode, tNode);
            treeView1.ExpandAll();  // Expand treeview at startup
        }

        private void get_picture(string szFileName)
        {
            try
            {
                Image myPic = Image.FromFile(szFileName);    // Open image file
                this.pictureBox1.BackgroundImage = myPic;   // picturebox background
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            return;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //MessageBox.Show(e.Node.Text);
            System.Diagnostics.Debug.Print("Node = {0}", e.Node.Text);
            /* Reform if structure to switch
            if (e.Node.Text == "bookstore")
            {
                System.Diagnostics.Debug.Print("Inside stuffs");
                //System.Diagnostics.Process.Start("1-1.png");  // Open file with system default application
                Image myPic = Image.FromFile("1-1.png");    // Open image file
                this.pictureBox1.BackgroundImage = myPic;   // picturebox background
            }
            */

            switch(e.Node.Text)
            {
                case "Advanced":
                    get_picture("Advanced.png");
                    /*
                    try
                    {
                        Image myPic = Image.FromFile("Advanced.png");    // Open image file
                        this.pictureBox1.BackgroundImage = myPic;   // picturebox background
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                    */
                    break;
                case "Configuration_Utility":
                    get_picture("Configuration_Utility.png");
                    /*
                    try
                    {
                        Image myPic = Image.FromFile("Configuration_Utility.png");    // Open image file
                        this.pictureBox1.BackgroundImage = myPic;   // picturebox background
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        return;
                    }
                    */
                    break;
                default:
                    return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            XmlTextWriter writer = new XmlTextWriter("product.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            createNode("1", "Product 1", "1000", writer);
            createNode("2", "Product 2", "2000", writer);
            createNode("3", "Product 3", "3000", writer);
            createNode("4", "Product 4", "4000", writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("XML File created ! ");
        }

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i = 0;
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                inTreeNode.Text = inXmlNode.InnerText.ToString();
            }
        }

        private void createNode(string pID, string pName, string pPrice, XmlTextWriter writer)
        {
            writer.WriteStartElement("Product");
            writer.WriteStartElement("Product_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_name");
            writer.WriteString(pName);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_price");
            writer.WriteString(pPrice);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Discard loading treeview by clicking button
            /*
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNode xmlnode;
            FileStream fs = new FileStream("tree.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.ChildNodes[1];
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(new TreeNode(xmldoc.DocumentElement.Name));
            TreeNode tNode;
            tNode = treeView1.Nodes[0];
            AddNode(xmlnode, tNode);
            */
            this.Close();
            return;
        }
    }
}
