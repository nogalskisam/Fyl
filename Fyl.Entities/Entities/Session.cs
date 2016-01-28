using Fyl.Library.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Entities
{
    public class Session
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid SessionId { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public DateTime ValidFromUtc { get; set; }

        [Required]
        public DateTime ValidUntilUtc { get; set; }

        [StringLength(46)]
        public string IpAddress { get; set; }

        public SessionDto ToDto()
        {
            return new SessionDto()
            {
                SessionId = this.SessionId,
                UserId = this.UserId,
                ValidFromUtc = this.ValidFromUtc,
                ValidUntilUtc = this.ValidUntilUtc,
                IpAddress = this.IpAddress
            };
        }

        public SessionDetailDto SessionDetailDto()
        {
            return new SessionDetailDto()
            {
                SessionId = this.SessionId,
                ValidFromUtc = this.ValidFromUtc,
                ValidUntilUtc = this.ValidUntilUtc,
                IpAddress = this.IpAddress,
                User = this.User != null ? this.User.ToDto() : null
            };
        }
    }
}
