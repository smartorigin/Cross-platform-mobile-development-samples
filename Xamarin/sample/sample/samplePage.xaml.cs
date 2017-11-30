using System;
using Xamarin.Forms;

namespace sample
{
    public partial class samplePage : ContentPage
    {
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Entry e1 = this.FindByName<Entry>("op1");
            Entry e2 = this.FindByName<Entry>("op2");
            Label l = this.FindByName<Label>("resultsLabel");

            try{
                int val1 = int.Parse(e1.Text);
                int val2 = int.Parse(e2.Text);
                l.Text = "Results = "+ DependencyService.Get<ISum>().sum(val1, val2).ToString();
            }
            catch(Exception ex){
                l.Text = ex.Message;
            }
        }

        public samplePage()
        {
            InitializeComponent();
        }
    }
}
