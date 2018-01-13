﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutomationTool
{
	public partial class About : Form
	{
		public About()
		{
			InitializeComponent();
		}

		private void About_Load(object sender, EventArgs e)
		{
			// Initialize build info text
			string buildNum = Properties.Settings.Default.Info_BuildNum.ToString();
			string buildDate = Properties.Settings.Default.Info_BuildDate.ToString();
			lbl_BuildInfo.Text = "Revision " + buildNum + " — " + buildDate;

			// Initialize license text
			text_License.SelectedText = "BSD 3-Clause License" + "\n\n";
			text_License.SelectedText = "Copyright (c) 2018, Aaron Gilbert All rights reserved." + "\n\n";
			text_License.SelectedText = "Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:" + "\n\n";

			text_License.SelectionBullet = true;
			text_License.SelectedText = "Redistributions of works must retain the original copyright notice, this list of conditions and the following disclaimer." + "\n";
			text_License.SelectedText = "Redistributions in binary form must reproduce the original copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution." + "\n";
			text_License.SelectedText = "Neither the name of the W3C nor the names of its contributors may be used to endorse or promote products derived from this work without specific prior written permission." + "\n";
			text_License.SelectionBullet = false;

			text_License.SelectedText = "\n" + "THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS \"AS IS\" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE." + "\n\n";
			text_License.SelectedText = "https://www.w3.org/Consortium/Legal/2008/03-bsd-license.html";
		}


		// When the user clicks the OK button:
		// Close the form.
		private void btn_Accept_Click(object sender, EventArgs e)
		{
			Close();
		}


		// When the user clicks a link in the license text:
		// Open the link in the default web browser.
		private void text_License_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Process.Start(e.LinkText);
		}


		// When the user clicks the "Check for updates" link:
		// Open a link to the GitHub page in the default web browser.
		private void link_Updates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			bool updateAvailable = AutomationTool.CheckForUpdates();
			if (updateAvailable)
			{
				Trace.WriteLine("Update is available. Pushing update prompt.");
				AutomationTool.StartUpdateFlow();
			}
			else
			{
				MessageBox.Show(this, "No new updates are available.", "Check for updates");
			}
		}


		// When the user clicks the "Contact" link:
		// Start a new e-mail to the contact e-mail address in the default e-mail program.
		private void link_Contact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("mailto:marth8880@gmail.com");
		}


		// When the user clicks the "Frayed Wires Studios" link:
		// Open a link to the FWS web site in the default web browser.
		private void link_FrayedWires_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://www.frayedwiresstudios.com/");
		}
	}
}
