using System.Windows.Forms;

namespace AcroniLibrary.CustomizingMethods
{
    public class FormManipulator
    {
        public static void CleanAllTextbox(Form form)
        {
            foreach (Control control in form.Controls)
            {
                if (control is TextBox)
                    control.ResetText();
            }
        }
    }
}
