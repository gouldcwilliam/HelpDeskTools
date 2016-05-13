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
    /// <summary>
    /// <see cref="EditCalls"/>
    /// </summary>
	public partial class EditCalls : Form
	{
		/// <summary>
		/// Call Editing Form - Used to initialize component
		/// </summary>
		public EditCalls()
		{
			InitializeComponent();
		}
		/// <summary>
		/// Call Editing Form
		/// </summary>
		/// <param name="id"></param>
		/// <param name="store"></param>
		/// <param name="date"></param>
		/// <param name="tech"></param>
		/// <param name="category"></param>
		/// <param name="topic"></param>
		/// <param name="details"></param>
		/// <param name="type"></param>
		/// <param name="trax"></param>
		/// <param name="url"></param>
		public EditCalls(string id, string store, string date, string tech, string category, string topic, string details, string type, bool trax, string url)
		{
			InitializeComponent();
			origFont = txtDetails.Font;
			gbTRAX.Visible = ckbTrax.Checked;

			ID = id;
			txtStore.Text = store;
			txtDate.Text = date;
			txtTech.Text = tech;
			Category = category;
			Topic = topic;
			txtDetails.Text = details;
			cmbType.Text = type;
			ckbTrax.Checked = trax;
			txtTRAX.Text = url;
			
		}

        /// <summary>
        /// <see cref="EditCalls"/>
        /// </summary>
        /// <param name="id"></param>
		public EditCalls(string id)
		{
			InitializeComponent();
			origFont = txtDetails.Font;
			gbTRAX.Visible = ckbTrax.Checked;
			string sql = "select * from [Calls]" +
				"inner join [Technicians] t on [Calls].[techID] = t.[id]" +
				"inner join [Categories] c on [Calls].[catID] = c.[id]" +
				"inner join [Topics] s on [Calls].[topID] = s.[id]" +
				"where [Calls].id = @ID";

			DataRow dr = Shared.SQL.Select(sql, new System.Data.SqlClient.SqlParameter("@ID", id)).Rows[0];
			
			ID = id;
			txtStore.Text = dr["store"].ToString() ;
			txtDate.Text = dr["date"].ToString();
			txtTech.Text = dr["initials"].ToString();
			Category = dr["category"].ToString();
			Topic = dr["topic"].ToString();
			txtDetails.Text = dr["details"].ToString();
			cmbType.Text = dr["type"].ToString();
			ckbTrax.Checked = (bool)dr["trax"];
			txtTRAX.Text = dr["url"].ToString();
		}

		const string requiredText = "<Required>"; //constant so we know if it changed or not without having to hope we typed it in correctly.
		Font origFont = new Font(FontFamily.GenericSansSerif, 8.25f, FontStyle.Regular);
		Font requiredFont = new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Italic | FontStyle.Bold);
		string Topic;
		string Category;
		string ID;
		// list categories and wrapups
		private List<WrapUp.wrapUp> listWrapUps = new List<WrapUp.wrapUp>();

		/*EVENTS*/
        /// <summary>
        /// event to update main form after button is clicked
        /// </summary>
		public event EventHandler ButtonClicked;

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
			Console.WriteLine(Environment.UserName.ToLower());
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
			WrapUp.wrapUp newWrapUp;

			foreach (DataRow dr in Shared.SQL.Select(Shared.SQLSettings.Default._CategoriesWithTopics).Rows)
			{
				category = dr["Category"].ToString();
				wrapup = dr["topic"].ToString();
				mandatory = (dr["Mandatory"].ToString().Contains("True"));
				newWrapUp = new WrapUp.wrapUp(category, wrapup, mandatory);
				listWrapUps.Add(newWrapUp);
			}
		}

		/// <summary>
		/// fill ckbWrapUps with wrap ups for Category in cmbCategory
		/// </summary>
		private void _fill_ckbTopics()
		{
			ckbTopics.Items.Clear();
			foreach (WrapUp.wrapUp wrap in listWrapUps.FindAll(x => x.Category == cmbCategory.Text))
			{
				ckbTopics.Items.Add(wrap.Text);
			}
		}

		/* HANDLERS */

		private void EditCalls_Load(object sender, EventArgs e)
		{
			cmbCategory.Text = Category;

			_getWrapUps();

			foreach (WrapUp.wrapUp wrapup in listWrapUps)
			{
				if (!cmbCategory.Items.Contains(wrapup.Category))
				{
					cmbCategory.Items.Add(wrapup.Category);
					cmbCategory.AutoCompleteCustomSource.Add(wrapup.Category);
				}
			}

			_fill_ckbTopics();

			try { ckbTopics.SetItemCheckState(ckbTopics.Items.IndexOf(Topic), CheckState.Checked); }
			catch (Exception ex) { Console.WriteLine("Edit Calls: Load: {0}", ex.Message);}
		}

		private void Form_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					btnCancel_Click(sender, null);
					break;
				case Keys.Enter:
					if(btnOK.Enabled)
					{
						btnOK_Click(sender, null);
					}
					break;
				default:
					break;
			}
		}

		private void ckbTopics_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (ckbTopics.SelectedItems.Count == 0) { return; }

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
				if (txtDetails.Text == string.Empty)
				{
					txtDetails.Text = requiredText;
					txtDetails.Font = requiredFont;
				}
			}
		}

		private void cmbCategory_MouseClick(object sender, MouseEventArgs e)
		{
			cmbCategory.DroppedDown = true;
		}

		private void cmbType_MouseClick(object sender, MouseEventArgs e)
		{
			cmbType.DroppedDown = true;
		}

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


		private void btnOK_Click(object sender, EventArgs e)
		{
			string details = txtDetails.Text;

			if (!_checkCategory())
			{
				MessageBox.Show("Invalid sCategory!", "Edit Calls sCategory", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if ((details.Trim() == string.Empty || details.Trim() == requiredText) && _mandatoryIssue()) //just in case they are retarded, instead of checking that it contains the required Text, let's only check that it is equivalent
			{
				MessageBox.Show("Empty Details!", "Edit Calls Solution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			else if (details.Contains(requiredText))
			{
				//remove the <Required> from it
				details = details.Replace(requiredText, string.Empty);
			}

			if (ckbTopics.CheckedItems.Count == 0)
			{
				MessageBox.Show("No Topic Selected!", "Edit Calls Topic", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (txtDetails.Text.Trim().Split(' ').Length < 15 && ckbTopics.CheckedItems[0].ToString() == "General Question")
			{
				MessageBox.Show("General Question Details Length Requirement not met.\nRequired minimum of 15 words.", "Wrap Up Details", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}

			if (ckbTrax.Checked && (txtTRAX.Text.Trim() == string.Empty || !txtTRAX.Text.Contains("trax")))
			{
				MessageBox.Show("Must include a valid TRAX URL", "Wrap Up Trax URL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}


			string url = txtTRAX.Text;
			if (!ckbTrax.Checked) { url = string.Empty; }

			if (!Shared.SQL.EditCalls_UpdateCall(ID, txtStore.Text, ckbTopics.CheckedItems[0].ToString(), txtDetails.Text, cmbType.Text, ckbTrax.Checked, url))
			{
				return;
			}

			if(ButtonClicked!=null) { ButtonClicked(this, e); }

			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

	}
}
