﻿using EntityCoreModel.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCoreModel.ViewModels
{
	public class BookVM
	{
		public Book Book { get; set; }
	
		public IEnumerable<SelectListItem> PublisherList { get; set; }
	}
}
