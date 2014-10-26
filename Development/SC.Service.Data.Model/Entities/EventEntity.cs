using SC.Service.Data.Model.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SC.Service.Data.Model.Entities
{
    public class EventEntity : IEntity<int>, ICreationTrackable, IUpdateTrackable
    {
        // IEntity
        public int Id { get; set; }

        // Event Specific
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Details { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        public string FacebookEventId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        // ICreationTrackable
        public DateTime CreatedOn { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        // IUpdateTrackable
        public DateTime UpdatedOn { get; set; }

        [Required]
        public string UpdatedBy { get; set; }
    }
}
