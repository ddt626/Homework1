using System;
using System.Linq;
using System.Collections.Generic;
	
namespace Homework1.Models
{   
	public  class SampleReportRepository : EFRepository<SampleReport>, ISampleReportRepository
	{

	}

	public  interface ISampleReportRepository : IRepository<SampleReport>
	{

	}
}