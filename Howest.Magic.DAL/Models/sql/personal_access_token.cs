#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Howest.MagicCards.DAL.Models.sql;

[Index(nameof(token), Name = "personal_access_tokens_token_unique", IsUnique = true)]
[Index(nameof(tokenable_type), nameof(tokenable_id), Name = "personal_access_tokens_tokenable_type_tokenable_id_index")]
public class personal_access_token
{
    [Key] public long id { get; set; }

    [Required] [StringLength(255)] public string tokenable_type { get; set; }

    public long tokenable_id { get; set; }

    [Required] [StringLength(255)] public string name { get; set; }

    [Required] [StringLength(64)] public string token { get; set; }

    public string abilities { get; set; }

    [Column(TypeName = "datetime")] public DateTime? last_used_at { get; set; }

    [Column(TypeName = "datetime")] public DateTime? created_at { get; set; }

    [Column(TypeName = "datetime")] public DateTime? updated_at { get; set; }
}