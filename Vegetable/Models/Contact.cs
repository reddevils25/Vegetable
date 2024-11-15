using System;
using System.Collections.Generic;

namespace Vegetable.Models;

public partial class Contact
{
    public string ContactId { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string? Phone { get; set; }

    public string InquiryMessage { get; set; } = null!;

    public DateTime? CreatedOn { get; set; }

    public bool? IsActive { get; set; }
}
