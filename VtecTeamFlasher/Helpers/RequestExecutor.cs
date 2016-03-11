using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VtecTeamFlasher.Helpers
{
    public  class RequestExecutor
    {
        public static void Execute(Action action)
        {
            try
            {
                action();
            }
            catch (FaultException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Необработанная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
