using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Movies
{
	public interface IVisitor
	{
		void Visit(Show show);
	}
}
