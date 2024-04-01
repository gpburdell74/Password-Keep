using PasswordKeep.Data.Entity;

namespace PasswordKeep.Ops
{
	/// <summary>
	/// Contains a list of, and provides the data source for identity service types for a data grid drop-down.
	/// </summary>
	/// <seealso cref="List{T}" />
	/// <seealso cref="IdentityServiceSelection"/>
	public sealed class IdentityServiceSelectionList : List<IdentityServiceSelection>
	{
		#region Constructor		
		/// <summary>
		/// Initializes a new instance of the <see cref="IdentityServiceSelectionList"/> class.
		/// </summary>
		public IdentityServiceSelectionList()
		{
			Add(new IdentityServiceSelection { Service = IdentityService.Apple });
			Add(new IdentityServiceSelection { Service = IdentityService.Google });
			Add(new IdentityServiceSelection { Service = IdentityService.Microsoft });
			Add(new IdentityServiceSelection { Service = IdentityService.Facebook });
			Add(new IdentityServiceSelection { Service = IdentityService.Custom });
		}
		#endregion
	}
}
