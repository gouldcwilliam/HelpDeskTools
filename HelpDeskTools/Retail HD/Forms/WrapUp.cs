using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Retail_HD.Forms
{

	public partial class WrapUp : Form
	{
        public WrapUp()
		{
			InitializeComponent();

			origFont = txtDetails.Font;
			gbTRAX.Visible = ckbTrax.Checked;
		}


		/// <summary>
		/// contains Category string wrapup Text and bool if Mandatory
		/// </summary>
		public class wrapUp
		{
			public wrapUp(string sCategory, string sText, bool bMandatory, bool bRequireLength)
			{
				Category = sCategory;
				Text = sText;
				Mandatory = bMandatory;
				Length = bRequireLength;
			}
			/// <summary>
			/// Container for each wrapups properties
			/// </summary>
			/// <param name="sCategory"></param>
			/// <param name="sText"></param>
			/// <param name="bMandatory"></param>
			public wrapUp(string bCategory, string bText, bool bMandatory)
			{
				Category = bCategory;
				Text = bText;
				Mandatory = bMandatory;
			}

			public string Category { get; set; }
			public string Text { get; set; }
			public bool Mandatory { get; set; }
			public bool Length = false;
		}

		/*PROERTIES*/
		const string requiredText = "<Required>"; //constant so we know if it changed or not without having to hope we typed it in correctly.
		Font origFont = new Font(FontFamily.GenericSansSerif, 8.25f, FontStyle.Regular);
		Font requiredFont = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Italic | FontStyle.Bold);
		// list categories and wrapups
		private List<wrapUp> listWrapUps = new List<wrapUp>();


		/*METHODS*/

		/// <summary>
		/// gets the first selected quick wrap
		/// </summary>
		/// <returns> the first selected quick wrap</returns>
		private string _getQuickWrap()
		{
			foreach (string item in ckbTopics.CheckedItems)
			{
				return item;
			}
			return string.Empty;
		}

		/// <summary>
		/// determines if wrapup requires a Mandatory issue
		/// </summary>
		/// <returns>true if issue requiredText</returns>
		private bool _mandatoryIssue()
		{
			if (ckbTopics.CheckedItems.Count == 0) { return false; }

			if (listWrapUps.Find(x => x.Text == ckbTopics.CheckedItems[0].ToString()).Mandatory)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// checks the selected Category against SQL categories
		/// </summary>
		/// <returns>true if Category exists in SQL</returns>
		private bool _checkCategory()
		{
			return (listWrapUps.FindAll(x => x.Category == cmbCategory.Text).Count > 0);
		}

		/// <summary>
		/// fills the wrapup list and Category list
		/// </summary>
		private void _getWrapUps()
		{
			string category = string.Empty;
			string wrapup = string.Empty;
			bool mandatory = false;
			wrapUp newWrapUp;

			foreach (DataRow dr in Shared.SQL.Select(Shared.SQLSettings.Default._CategoriesWithTopics).Rows)
			{
				category = dr["Category"].ToString();
				wrapup = dr["topic"].ToString();
				mandatory = (dr["Mandatory"].ToString().Contains("True"));
				newWrapUp = new wrapUp(category, wrapup, mandatory);
				listWrapUps.Add(newWrapUp);
			}
		}

		/// <summary>
		/// fill ckbWrapUps with wrap ups for Category in cmbCategory
		/// </summary>
		private void _fill_ckbTopics()
		{
			ckbTopics.Items.Clear();
			foreach (wrapUp wrap in listWrapUps.FindAll(x => x.Category == cmbCategory.Text))
			{
				ckbTopics.Items.Add(wrap.Text);
			}
		}


		/*LOAD*/

		/// <summary>
		/// things to do on load
		/// </summary>
		private void frmWrapUp_Load(object sender, EventArgs e)
		{
			_getWrapUps();

			foreach (wrapUp wrapup in listWrapUps)
			{
				if (!cmbCategory.Items.Contains(wrapup.Category)) 
				{ 
					cmbCategory.Items.Add(wrapup.Category);
					cmbCategory.AutoCompleteCustomSource.Add(wrapup.Category);
				}
			}

			if (Info.cashier.Trim() != string.Empty)
			{
				txtDetails.Text += "Cashier #: " + Info.cashier;
			}

			_fill_ckbTopics();

			DataTable dt = Shared.SQL.dt_LastCategory();
			if (dt.Rows.Count > 0)
			{
				if (dt.Rows[0][0] != null)
				{
					cmbCategory.Text = dt.Rows[0][0].ToString();
				}
			}

			txtStore.Text = Info.store.ToString();
		}

		private void frmWrapUp_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (this.DialogResult == System.Windows.Forms.DialogResult.None)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
		}


		/*BUTTONS*/

		/// <summary>
		/// what to do when OK clicked
		/// </summary>
		private void btnOK_Click(object sender, EventArgs e)
		{
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
			string details = txtDetails.Text;
			if (ckbTopics.CheckedItems.Count == 0)
			{
                MessageBox.Show("You must select a category!", "Wrap Up Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.DialogResult = System.Windows.Forms.DialogResult.None;
				return;
			}
			if (!_checkCategory())
			{
				MessageBox.Show("Invalid Category!", "Wrap Up Category", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
				return;
			}

            if ((details.Trim() == string.Empty || details.Trim() == requiredText) && _mandatoryIssue()) //just in case they are retarded, instead of checking that it contains the required Text, let's only check that it is equivalent
            {
                MessageBox.Show("Empty Details!", "Wrap Up Solution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }
            else if (details.Contains(requiredText))
            {
                //remove the <Required> from it
                details = details.Replace(requiredText, string.Empty);
            }

			if (ckbTopics.CheckedItems.Count == 0)
			{
				MessageBox.Show("No Topic Selected!", "Wrap Up Topic", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
				return;
			}

            if (txtDetails.Text.Trim().Split(' ').Length < 15 && ckbTopics.CheckedItems[0].ToString() == "General Question") 
            {
                MessageBox.Show("General Question Details Length Requirement not met.\nRequired minimum of 15 words.", "Wrap Up Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
                return;
            }

			if (ckbTrax.Checked && (txtTRAX.Text.Trim() == string.Empty || !txtTRAX.Text.Contains("trax")))
			{
				MessageBox.Show("Must include a valid TRAX URL", "Wrap Up Trax URL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
				return;
			}

            string url = txtTRAX.Text;

            if (!ckbTrax.Checked) { url = string.Empty; }

			if (!Shared.SQL.WrapUp_InsertCall(txtStore.Text, details, cmbCategory.Text, ckbTopics.CheckedItems[0].ToString(),  cmbType.Text, Environment.UserName.ToUpper(), ckbTrax.Checked, url))
			{
                this.DialogResult = System.Windows.Forms.DialogResult.None;
				return;
			}
		}

		/// <summary>
		/// closes form
		/// </summary>
		private void btnCancel_Click(object sender, EventArgs e)
		{
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		}


		/*HANDLERS*/

		/// <summary>
		/// opens dropdown on click
		/// </summary>
        private void cmbCategory_MouseClick(object sender, MouseEventArgs e)
        {
			cmbCategory.DroppedDown = true;
        }

		/// <summary>
		/// opens dropdown on click
		/// </summary>
        private void cmbType_MouseClick(object sender, MouseEventArgs e)
        {
			cmbType.DroppedDown = true;
        }

		/// <summary>
		/// key presses for cancel button
		/// </summary>
		private void btnCancel_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					btnCancel_Click(sender, null);
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// key presses for the form
		/// </summary>
		private void frmWrapUp_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					btnCancel_Click(sender, null);
					break;
				case Keys.Return:
					btnOK_Click(sender, null);
					break;
				case Keys.W:
					if (e.Modifiers == Keys.Control)
					{
						Forms.AddQuickWrap addQuickWrap = new Forms.AddQuickWrap(cmbCategory.Items);
						addQuickWrap.ShowDialog();
						listWrapUps.Clear();
						frmWrapUp_Load(sender, e);
					}
					break;
				default:
					break;
			}
		}


		private void ckbTopic_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			var temp = ckbTopics.SelectedItem;

			if (listWrapUps.Find(x => x.Text == ckbTopics.SelectedItem.ToString()).Mandatory)
			{
				if (txtDetails.Text == "" || txtDetails.Text == requiredText)
				{
					txtDetails.Text = requiredText;
					txtDetails.Font = requiredFont;
				}
			}
			else
			{
				if (txtDetails.Text == "" || txtDetails.Text == requiredText)
				{
					txtDetails.Text = "";
				}
				txtDetails.Font = origFont;
				
			}

			_fill_ckbTopics();

			ckbTopics.SelectedItem = temp;
		}


		private void txtDetails_Enter(object sender, EventArgs e)
		{
			try
			{
				if (listWrapUps.Find(x => x.Text == ckbTopics.SelectedItem.ToString()).Mandatory)
				{
					if (txtDetails.Text == requiredText)
					{
						txtDetails.Text = string.Empty;
						txtDetails.Font = origFont;
					}
				}
			}
			catch (Exception) { ;}

		}

		private void txtDetails_Click(object sender, EventArgs e)
		{
			if (txtDetails.Text == requiredText)
			{
                txtDetails.Text = string.Empty;
                txtDetails.Font = origFont;
			}
		}

        private void txtDetails_Leave(object sender, EventArgs e)
        {
			if (listWrapUps.Count() < 1) { return; }
			if (ckbTopics.SelectedItems.Count < 1) { return; }
            if (listWrapUps.Find(x => x.Text == ckbTopics.SelectedItem.ToString()).Mandatory)
            {
                if (txtDetails.Text.Trim() == string.Empty)
                {
                    txtDetails.Text = requiredText;
                    txtDetails.Font = requiredFont;
                }
            }
		}

		private void cmbCategory_TextChanged(object sender, EventArgs e)
		{
			_fill_ckbTopics();
		}

		private void ckbTrax_CheckedChanged(object sender, EventArgs e)
		{
			gbTRAX.Visible = ckbTrax.Checked;
		}

		private void txtTRAX_Click(object sender, EventArgs e)
		{
			txtTRAX.SelectAll();
		}

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //reset the txt box when this changes
            if (txtDetails.Text == requiredText)
            {
                txtDetails.Clear();
                txtDetails.Font = origFont;
            }
            else if (txtDetails.Font == requiredFont)
            {
                txtDetails.Font = origFont;
            }
        }
	}

}
