using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Common
{
	public class BaseModel : IModelEvent
	{
        public BaseModel()
        {
			OnBeforeDelete += OnOnBeforeSave;

		}
		private bool? _isNewRecord;
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public bool Deleted { get; set; }

		[NotMapped]
		[JsonIgnore]
		public bool IsNewRecord
		{
			get
			{
				if (_isNewRecord == null)
					return Id == Guid.Empty;

				return _isNewRecord.Value;
			}
			set { _isNewRecord = value; }
		}
		public bool NewRecord { get; set; }

		[Timestamp]
		public byte[] RowVersion { get; set; }

		protected virtual void OnOnBeforeSave(object context)
        {

        }

		//Implementation of IModelEvent
		public event ModelEvent OnAfterInitialize;
		public event ModelEvent OnBeforeSave;
		public event ModelEvent OnAfterSave;
		public event ModelEvent OnBeforeDelete;
		public event ModelEvent OnAfterDelete;
		public void DoOnAfterInitialize(object context)
		{
			if (OnAfterInitialize != null)
				OnAfterInitialize(context);
		}

		public void DoOnBeforeSave(object context)
		{
			if (OnBeforeSave != null)
				OnBeforeSave(context);
		}

		public void DoOnAfterSave(object context)
		{
			if (OnAfterSave != null)
				OnAfterSave(context);
		}

		public void DoOnBeforeDelete(object context)
		{
			if (OnBeforeDelete != null)
				OnBeforeDelete(context);
		}

		public void DoOnAfterDelete(object context)
		{
			if (OnAfterDelete != null)
				OnAfterDelete(context);
		}


	}
}
