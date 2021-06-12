using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EntityFrameWork
{
	/// <summary>
	///	IModifiableEntityis a template for creating view models
	/// </summary>
	public interface IModifiableEntity
	{
		string Name { get; set; }
	}
}
