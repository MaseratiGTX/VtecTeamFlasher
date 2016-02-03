using DevExpress.Web.ASPxEditors;
using WebAppCommons.Classes.Controls.ASPx;
using WebAppCommons.Classes.Controls.PersistedStates.StateManagers.Base;
using WebAppCommons.Classes.Controls.PersistedStates.StateObjects;

namespace WebAppCommons.Classes.Controls.PersistedStates.StateManagers
{
    public class ASPxEditStateManager : BaseControlStateManager<ASPxEdit, ASPxEditState>
    {
        public override ASPxEditState CalculateState()
        {
            var result = base.CalculateState();
                result.ClientEnabled = SourceControl.ClientEnabled;
                result.Value = SourceControl.GetValue();

            return result;
        }

        public override void ApplyState(ASPxEditState state)
        {
            base.ApplyState(state);

            SourceControl.ClientEnabled = state.ClientEnabled;
            SourceControl.SetValue(state.Value);
        }
    }
}