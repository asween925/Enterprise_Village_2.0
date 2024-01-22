
public void EVBusinessLocation()
{
    if (this.currentLocation_ddl.SelectedValue == "EV")
    {
        this.businessUsed_ddl.Enabled = true;
        this.businessUsed_ddl.Items.Remove("N/A");
    }
    else
    {
        this.businessUsed_ddl.Items.Insert(0, "N/A");
        this.businessUsed_ddl.SelectedIndex = this.businessUsed_ddl.Items.IndexOf(this.businessUsed_ddl.Items.FindByValue("N/A"));
        this.businessUsed_ddl.Enabled = false;

    }
}
