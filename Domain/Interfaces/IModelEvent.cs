using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public delegate void ModelEvent(object context);
    public interface IModelEvent
    {
		/// <summary> Use this an event when the model is materialized after load from the DB </summary>
		event ModelEvent OnAfterInitialize;
		event ModelEvent OnBeforeSave;
		event ModelEvent OnAfterSave;
		event ModelEvent OnBeforeDelete;
		event ModelEvent OnAfterDelete;

		void DoOnAfterInitialize(object context);
		void DoOnBeforeSave(object context);
		void DoOnAfterSave(object context);
		void DoOnBeforeDelete(object context);
		void DoOnAfterDelete(object context);
	}
}
