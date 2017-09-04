
/*****************************************************

This is an implementation of The Evaluation Form

BY DEVANSHU D. SHETH
dds160030
CS6326


It uses the Data Entry Form data file and calculates various parameters such as

1. Total number of records
2. Min, Max and Avg Data Entry times
3. Inter-record Min, Max and Avg times
4. Backspace Count 

It writes it back to the file CS6326Asg3.txt. If there is not one, it will create it for you.


******************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Asg3_dds160030
{
    public partial class EvaluationForm : Form
    {
        //Record read from data file
        private MyObject readrecord;

        //List of MyObjects
        List<MyObject> myobjects = new List<MyObject>();

        //List of TimeSpan to find times for record saving
        List<TimeSpan> timeSpanList = new List<TimeSpan>();

        //List of TimeSpan to find times in between records
        List<TimeSpan> intertimeSpanList = new List<TimeSpan>();

        //Total time
        TimeSpan totaltime;

        string FilePath = null;
        string OutputFilePath = "CS6326Asg3.txt";

        public EvaluationForm()
        {
            InitializeComponent();
          

        }

        //method to return the various times needed for program
        //calculates all times required such as minimum record save time, maximum record save time, average record save time
        //also calculates the inter records times for the same
        //displays all these records in listview
        private void getTimes()
        {
            //get the count of records in myobjects
            //since 10 records will be entered, it will be 10
            int itemcount = myobjects.Count();

            //Here we calculate the timespan between starting to save a record and saving a record
            foreach (MyObject x in myobjects)
            {
                //get the data corresponding to start and end times from myobjects
                DateTime start = Convert.ToDateTime(x.startTime);
                DateTime end = Convert.ToDateTime(x.endTime);

                //calculate difference
                TimeSpan difference = end - start;

                //add to total time all saving times
                totaltime += difference;

                //add each timespan to a List of TimeSpans
                timeSpanList.Add(difference);
            }

            //Here we calculate the timespan between two records
            for(int j = 0, k = 1; k < itemcount ; j++, k++)
            {
                //get the records of the end time of current record and start time of next record
                DateTime endof1 = Convert.ToDateTime(myobjects[j].endTime);
                DateTime startof2 = Convert.ToDateTime(myobjects[k].startTime);

                //calculate difference between them
                TimeSpan interdiff = startof2 - endof1;

                //add the inter record time to total time
                totaltime += interdiff;
                
                //add to List of TimeSpan intertimeSpanList
                intertimeSpanList.Add(interdiff);
            }

            //get the max and min using built-in List capability
            TimeSpan max = timeSpanList.Max();
            TimeSpan min = timeSpanList.Min();
            TimeSpan intermax = intertimeSpanList.Max();
            TimeSpan intermin = intertimeSpanList.Min();


            //get the average from all values of timeSpanList and intertimeSpanList
            //cannot be done directly, first we convert to milliseconds as average can be done on int
            TimeSpan timeaverage = TimeSpan.FromMilliseconds(timeSpanList.Average(i => i.TotalMilliseconds));
            TimeSpan intertimeaverage = TimeSpan.FromMilliseconds(intertimeSpanList.Average(i => i.TotalMilliseconds));

            //convert all obtainted times to the appropriate MM:SS format
            string maxTime = changeFormat(max);
            string minTime = changeFormat(min);
            string avgTime = changeFormat(timeaverage);
            string totalTime = changeFormat(totaltime);
            string intermaxTime = changeFormat(intermax);
            string interminTime = changeFormat(intermin);
            string interavgTime = changeFormat(intertimeaverage);

            //Add all these times to ListView
            ListViewItem li = new ListViewItem();
            listValues.Items.Add("Minimum Entry Time: " + minTime);
            listValues.Items.Add("Maximum Entry Time: " + maxTime);
            listValues.Items.Add("Average Entry Time: " + avgTime);
            listValues.Items.Add("Minimum inter-record Time: " + interminTime);
            listValues.Items.Add("Maximum inter-record Time: " + intermaxTime);
            listValues.Items.Add("Average inter-record Time: " + interavgTime);
            listValues.Items.Add("Total Time: " + totalTime);

            //write to datafile the times
            using (StreamWriter w = File.AppendText(OutputFilePath))
            {

                w.WriteLine("Minimum Entry Time: " + minTime);
                w.WriteLine("Maximum Entry Time: " + maxTime);
                w.WriteLine("Average Entry Time: " + avgTime);
                w.WriteLine("Minimum inter-record Time: " + interminTime);
                w.WriteLine("Maximum inter-record Time: " + intermaxTime);
                w.WriteLine("Average inter-record Time: " + interavgTime);
                w.WriteLine("Total Time: " + totalTime);
                
                w.Close();
            }
        }

        //converts the default TimeSpan HH:MM:SS format to MM:SS
        //parameter TimeSpan value in HH:MM:SS
        //returns string in MM:SS format
        private string changeFormat(TimeSpan time)
        {
            return ((time < TimeSpan.Zero) ? "-" : "") + time.ToString(@"mm\:ss");
        }

        //When browse button is clicked
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //clear listview items if you want to run same program multiple times with different data files
            listValues.Clear();

            //use built-in ShowDialog of to get the File Explorer
            DialogResult result = FileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
               //the filepath obtained by the File Explorer
                string file = FileDialog.FileName;

                //displays file found
                    ctlFilePath.Text = file;
                    StatusBar.Refresh();
                    lblstatusbar.Text = "File Found";
            }
    }
        //triggered when accept button is clicked
        //also the from accept button
        private void btnAccept_Click(object sender, EventArgs e)
        {
                //count for backspace
                int backspacecount = 0;

            string[] records = null;
            //Read all lines from File to check if any data is there in text file and store in array records.
            //File path must not be null at this stage
            if (FilePath != null)
            {
                //File must exist at this stage, do nothing otherwise.
                //Wait for Form Load event
                if (File.Exists(FilePath))
                {
                    records = System.IO.File.ReadAllLines(FilePath);

                    //Parse the lines into their individual fields.
                    //For example, the part associated with FirstName goes to MyObject.FirstName
                    foreach (string x in records)
                    {
                        string[] data = x.Split('\t');
                        readrecord = new MyObject();
                        readrecord.MyObjectID = data[0] + " " + data[2] + " " + data[1];
                        readrecord.FirstName = data[0];
                        readrecord.Minit = data[2];
                        readrecord.LastName = data[1];
                        readrecord.Add1 = data[3];
                        readrecord.Add2 = data[4];
                        readrecord.City = data[5];
                        readrecord.State = data[6];
                        readrecord.ZipCode = data[7];
                        readrecord.Phone = data[8];
                        readrecord.Email = data[9];
                        if (data[10] == "True")
                            readrecord.ProofofPurchase = true;
                        else
                            readrecord.ProofofPurchase = false;
                        readrecord.Date = data[11];
                        readrecord.startTime = data[12];
                        readrecord.endTime = data[13];
                        readrecord.backspace = data[14];
                        //convert string backspace which has count of backspace to int
                        backspacecount += Convert.ToInt32(data[14]);
                        //Add these fields to myobjects array of MyObject
                        myobjects.Add(readrecord);
                    }
                    //count the number of records read and stored in myobjects
                    int countrecords = myobjects.Count();

                    //add to listview the count
                    ListViewItem li = new ListViewItem();
                    listValues.Items.Add("Number of Items: " + countrecords.ToString());

                    //write to text file the number of records
                    FileStream file = File.Open(OutputFilePath, FileMode.Create);
                    using (StreamWriter w = new StreamWriter(file))
                    {
                        w.WriteLine("Number of Items: " + countrecords.ToString());
                        w.Close();
                    }
                    //call the getTimes() method which will calculate all the times and display in listview in order needed
                    getTimes();
                    //add to listview the backspace count
                    listValues.Items.Add("Backspace Count: " + backspacecount.ToString());

                    //write to data file the backspace count
                    StreamWriter sw = File.AppendText(OutputFilePath);
                    sw.WriteLine("Backspace Count: " + backspacecount.ToString());
                    sw.Close();

                    //finally display the successfull message that the file was found and the required details were found
                    StatusBar.Refresh();
                    lblstatusbar.Text = "File Found and Details Obtained";
                    StatusBar.Refresh();
                }
            }
        }
        
        //triggered whenever textbox is changed
        //also the form load event
        private void ctlFilePath_TextChanged(object sender, EventArgs e)
        {
            //if textbox is empty wait for user
            if (ctlFilePath.TextLength == 0)
            {
                StatusBar.Refresh();
                lblstatusbar.Text = "Waiting for entry";
            }
            else
            {
                //clear listview items if you want to run same program multiple times with different data files
                listValues.Clear();

                //clear myobjects if you want to run same program multiple times with different data files
                myobjects.Clear();

                //reset totaltime if you want to run same program multiple times with different data files
                totaltime = TimeSpan.Zero;

                if (ctlFilePath.TextLength > 0)
                {
                    FilePath = ctlFilePath.Text;
                }
                //clear textbox after the file path has been noted
                //   ctlFilePath.Clear();

                //display file does not exist if filepath is invalid
                if ((File.Exists(FilePath)) == false)
                {
                  
                        StatusBar.Refresh();
                        lblstatusbar.Text = "File Not Found";
                }
                else
                {
                    StatusBar.Refresh();
                    lblstatusbar.Text = "File Found";
                }
            }
        }
        }
    }
