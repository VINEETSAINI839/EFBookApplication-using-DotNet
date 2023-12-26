using System;
using System.Collections.Generic;

namespace BookEF2.Models;

public partial class TblBook
{
    public int BookId { get; set; }

    public string? BookName { get; set; }

    public string? BookAuthor { get; set; }

    public decimal? BookPrice { get; set; }
}
