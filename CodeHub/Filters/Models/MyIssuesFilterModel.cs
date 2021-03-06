using System;
using CodeFramework.Filters.Models;
using System.Runtime.Serialization;

namespace CodeHub.Filters.Models
{
	public class MyIssuesFilterModel : FilterModel<MyIssuesFilterModel>
    {
		public bool Ascending { get; set; }

		public string Labels { get; set; }

		public Filter FilterType { get; set; }

        public bool Open { get; set; }

		public DateTime? Since { get; set; }

        public Sort SortType { get; set; }

		public MyIssuesFilterModel()
        {
            Ascending = false;
            Open = true;
            FilterType = Filter.All;
            SortType = Sort.None;
        }

        /// <summary>
        /// Predefined 'Open' filter
        /// </summary>
        public static MyIssuesFilterModel CreateOpenFilter()
        {
            return new MyIssuesFilterModel { FilterType = Filter.All, Open = true };
        }

        /// <summary>
        /// Predefined 'Closed' filter
        /// </summary>
        public static MyIssuesFilterModel CreateClosedFilter()
        {
            return new MyIssuesFilterModel { FilterType = Filter.All, Open = false };
        }

        public override MyIssuesFilterModel Clone()
        {
            return (MyIssuesFilterModel)this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != typeof(MyIssuesFilterModel))
                return false;
            MyIssuesFilterModel other = (MyIssuesFilterModel)obj;
            return Ascending == other.Ascending && Labels == other.Labels && FilterType == other.FilterType && Open == other.Open && Since == other.Since && SortType == other.SortType;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Ascending.GetHashCode() ^ (Labels != null ? Labels.GetHashCode() : 0) ^ FilterType.GetHashCode() ^ Open.GetHashCode() ^ Since.GetHashCode() ^ SortType.GetHashCode();
            }
        }
        
        public enum Sort : int
        {
            None,
            Created,
            Updated,
            Comments
        }

		public enum Filter : int
		{
            [EnumDescription("Assigned To You")]
			Assigned,
            [EnumDescription("Created By You")]
			Created,
            [EnumDescription("Mentioning You")]
			Mentioned,
            [EnumDescription("Issues Subscribed To")]
			Subscribed,
			All
		}
    }
}

