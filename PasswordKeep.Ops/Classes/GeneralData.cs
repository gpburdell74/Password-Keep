using Adaptive.Intelligence.Shared;
using PasswordKeep.Data.Entity;
using System.Reflection.Metadata.Ecma335;

namespace PasswordKeep.Ops
{
    /// <summary>
    /// Represents and manages a general data type entry.
    /// </summary>
    /// <seealso cref="BusinessBase{T}" />
    public sealed class GeneralData : BusinessBase<RawDataEntry>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralData"/> class.
        /// </summary>
        /// <remarks>
        /// This is the default constructor.
        /// </remarks>
        public GeneralData() : base()
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralData"/> class.
        /// </summary>
        /// <param name="entity">
        /// The <see cref="RawDataEntry"/> data entity used to populate the instance.
        /// </param>
        public GeneralData(RawDataEntry entity) : base(entity)
        {

        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the available credit amount.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> specifying the available credit amount, in USD.
        /// </value>
        public float Available
        {
            get
            {
                if (Data == null)
                    return 0;
                else
                    return Data.Available;
            }
            set
            {
                if (Data != null && Data.Available != value)
                {
                    Data.Available = value;
                    OnPropertyChanged(nameof(Available));
                }
            }
        }
        /// <summary>
        /// Gets or sets the current balance.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> specifying the current balance, in USD.
        /// </value>
        public float CurrentBalance
        {
            get
            {
                if (Data == null)
                    return 0;
                else
                    return Data.Available;
            }
            set
            {
                if (Data != null && Data.Available != value)
                {
                    Data.Available = value;
                    OnPropertyChanged(nameof(Available));
                }
            }
        }
		/// <summary>
		/// Gets or sets the description text for the item.
		/// </summary>
		/// <value>
		/// A string containing the item description, or <b>null</b>.
		/// </value>
		public string? Description
		{
			get
			{
				if (Data == null)
					return null;
				else
					return Data.Description;
			}
			set
			{
				if (Data != null && Data.Description != value)
				{
					Data.Description = value;
					OnPropertyChanged(nameof(Description));
				}
			}
		}
		/// <summary>
		/// Gets or sets the date the bill was last paid.
		/// </summary>
		/// <value>
		/// The <see cref="DateTime"/> the bill was last paid, or <b>null</b>.
		/// </value>
		public DateTime? LastPaid
        {
            get => Data?.LastPaid;
            set
            {
                if (Data != null && Data.LastPaid != value)
                {
                    Data.LastPaid = value;
                    OnPropertyChanged(nameof(LastPaid));
                }
            }
        }
        /// <summary>
        /// Gets or sets the minimum due amount.
        /// </summary>
        /// <value>
        /// A <see cref="float"/> specifying the minimum due amount, in USD.
        /// </value>
        public float MinimumDue
        {
            get
            {
                if (Data == null)
                    return 0;
                else
                    return Data.Available;
            }
            set
            {
                if (Data != null && Data.Available != value)
                {
                    Data.Available = value;
                    OnPropertyChanged(nameof(Available));
                }
            }
        }
		/// <summary>
		/// Gets or sets the name for the entry.
		/// </summary>
		/// <value>
		/// A string containing the name value for the entry.
		/// </value>
		public string? Name
        {
            get
            {
                if (Data == null)
                    return null;
                else
                    return Data.Name;
            }
            set
			{
				if (Data != null && Data.Name != value)
				{
					Data.Name = value;
					OnPropertyChanged(nameof(Name));
				}
			}
		}
		/// <summary>
		/// Gets or sets the next due date for the bill.
		/// </summary>
		/// <value>
		/// The <see cref="DateTime"/> specifying the next due date, or <b>null</b>.
		/// </value>
		public DateTime? NextDue
        {
            get => Data?.NextDue;
            set
            {
                if (Data != null && Data.NextDue != value)
                {
                    Data.NextDue = value;
                    OnPropertyChanged(nameof(NextDue));
                }
            }
        }
		/// <summary>
		/// Gets or sets the password value for the item.
		/// </summary>
		/// <value>
		/// A string containing the item value, or <b>null</b>.
		/// </value>
		public string? Password
		{
            get { return Data?.Password; }
			set
			{
				if (Data != null && Data.Password != value)
				{
					Data.Password = value;
					OnPropertyChanged(nameof(Password));
				}
			}
		}
		/// <summary>
		/// Gets or sets the reference to the list of security answers.
		/// </summary>
		/// <value>
		/// An <see cref="AdaptiveStringCollection"/> instance containing the sequential list of security answers.
		/// </value>
		public AdaptiveStringCollection? SecurityAnswers => Data?.SecurityAnswers;
        /// <summary>
        /// Gets or sets the reference to the list of security questions.
        /// </summary>
        /// <value>
        /// An <see cref="AdaptiveStringCollection"/> instance containing the sequential list of security questions.
        /// </value>
        public AdaptiveStringCollection? SecurityQuestions => Data?.SecurityQuestions;
		/// <summary>
		/// Gets the security question count.
		/// </summary>
		/// <value>
		/// An integer specifying the number of security question/answer pairs in the instance.
		/// </value>
		public int SecurityQuestionCount
        {
            get
            {
                if (Data == null || Data.SecurityQuestions == null)
                    return 0;
                else
                    return Data.SecurityQuestions.Count;
            }
        }
        /// <summary>
        /// Gets or sets the associated URL for the item.
        /// </summary>
        /// <value>
        /// A string containing the URL value, or <b>null</b>.
        /// </value>
        public string? Url
        {
			get { return Data?.Url; }
			set
			{
				if (Data != null && Data.Url != value)
				{
					Data.Url = value;
					OnPropertyChanged(nameof(Url));
				}
			}

		}
		/// <summary>
		/// Gets or sets the User ID / email / login name value for the item.
		/// </summary>
		/// <value>
		/// A string containing the user identity value, or <b>null</b>.
		/// </value>
		public string? UserId
		{
			get { return Data?.UserId; }
			set
			{
				if (Data != null && Data.UserId != value)
				{
					Data.UserId = value;
					OnPropertyChanged(nameof(UserId));
				}
			}

		}
		#endregion

		#region Protected Method Overrides                
		/// <summary>
		/// Creates the new entity instance.
		/// </summary>
		/// <returns>
		/// A new <see cref="RawDataEntry"/> instance.
		/// </returns>
		protected override RawDataEntry CreateEntity()
        {
            return new RawDataEntry();
        }
		#endregion

		#region Public Methods / Functions        
		/// <summary>
		/// Adds the security question and answer to the current instance's lists.
		/// </summary>
		/// <param name="question">
        /// A string containing the question text.
        /// </param>
		/// <param name="answer">
        /// A string containing the answer text.
        /// </param>
		public void AddSecurityQuestionAndAnswer(string question, string answer)
        {
            if (Data != null && Data.SecurityAnswers != null && Data.SecurityQuestions != null)
            {
                Data.SecurityQuestions.Add(question);
                Data.SecurityAnswers.Add(answer);
            }
		}
		/// <summary>
		/// Removes the security question and answer.
		/// </summary>
		/// <param name="index">
        /// An integer specifying the ordinal index of the items to be removed.
        /// </param>
		public void RemoveSecurityQuestionAndAnswer(int index)
        {
			if (Data != null && Data.SecurityAnswers != null && Data.SecurityQuestions != null && index < 
                Data.SecurityQuestions.Count)
			{
                Data.SecurityQuestions.RemoveAt(index);
                Data.SecurityAnswers.RemoveAt(index);
			}
		}
		#endregion
	}
}
