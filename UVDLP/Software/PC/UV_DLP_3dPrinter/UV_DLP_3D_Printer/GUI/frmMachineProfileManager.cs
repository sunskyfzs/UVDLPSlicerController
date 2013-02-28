using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmMachineProfileManager : Form
    {
        public frmMachineProfileManager()
        {
            InitializeComponent();
            UpdateProfiles();
            UpdateButtons();
        }
        private void UpdateButtons() 
        {
            int idx = lstMachineProfiles.SelectedIndex;
            if (idx == -1)
            {
                cmdCopy.Enabled = false;
                cmdDelete.Enabled = false;
                cmdEdit.Enabled = false;
            }
            else 
            {
                cmdCopy.Enabled = true;
                cmdDelete.Enabled = true;
                cmdEdit.Enabled = true;
            
            }
        }
        private string FNFromIndex(int idx) 
        {
            string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathMachines, "*.machine");
            return filePaths[idx];
        }
        private void UpdateProfiles() 
        {
            // get a list of profiles in the /machines directory
            string[] filePaths = Directory.GetFiles(UVDLPApp.Instance().m_PathMachines, "*.machine");
            lstMachineProfiles.Items.Clear();
            foreach (String profile in filePaths) 
            {
                String pn = Path.GetFileNameWithoutExtension(profile);
                lstMachineProfiles.Items.Add(pn);                
            }
        }
        private void cmdNew_Click(object sender, EventArgs e)
        {
            // create a new profile, give it a name
            frmProfileName fpn = new frmProfileName();
            fpn.ShowDialog();
            String pf = fpn.ProfileName;
            if (pf.Length > 0) 
            {
                //create a new profile with that name
                String fn = UVDLPApp.Instance().m_PathMachines;
                fn += UVDLPApp.m_pathsep;
                fn += pf;
                fn += ".machine";
                MachineConfig mc = new MachineConfig();
                mc.m_name = pf;
                if (!mc.Save(fn)) 
                {
                    DebugLogger.Instance().LogRecord("Error Saving new machine profile " + fn);
                    return;
                }
                UpdateProfiles();
            }
        }

        private void lstMachineProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMachineProfiles.SelectedIndex != -1) 
            {
                UpdateButtons();
            }
        }

        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (lstMachineProfiles.SelectedIndex != -1)
            {
                string fn = FNFromIndex(lstMachineProfiles.SelectedIndex);
                if (fn != null) 
                {
                    MachineConfig mc = null;
                    if (UVDLPApp.Instance().m_printerinfo.m_filename.Equals(fn))
                    {
                        mc = UVDLPApp.Instance().m_printerinfo; // current machine profile
                    }
                    else
                    {
                        mc = new MachineConfig(); // existing but not current
                        mc.Load(fn);
                    }
                    frmMachineConfig maccfg = new frmMachineConfig(ref mc);
                    maccfg.Show();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstMachineProfiles.SelectedIndex != -1)
                {
                    if (MessageBox.Show(this, "Are you sure you want to delete this Machine Profile?", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                    {
                        //delete file    
                        File.Delete(FNFromIndex(lstMachineProfiles.SelectedIndex));
                        UpdateProfiles();
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
    }
}
