using UnityEngine;
using System;
using System.Collections.Generic;

namespace Sophie
{
	public class CellTypeData
	{
		public static readonly CellTypeData Nucleus = new CellTypeData (new Color (1, 0, 0), false);
		public static readonly CellTypeData Tissue = new CellTypeData (new Color (0, 0, 0), true);
		public static readonly CellTypeData Grower = new CellTypeData (new Color (0, 1, 0), true);
		public static readonly CellTypeData Trap = new CellTypeData (new Color (0, 0, 1), true);
		public static readonly CellTypeData Lookout = new CellTypeData (new Color (0.5f, 0.5f, 0.5f), true);

		private Color color;
		private bool canBuild;

		#region Properties
		public Color Color
		{
			get { return color; }
		}

		public bool CanBuild
		{
			get { return canBuild; }
		}
		#endregion 

		public CellTypeData (Color color, bool canBuild)
		{
			this.color = color;
			this.canBuild = canBuild;
		}

		public static List<CellTypeData> GetBuildable()
		{
			List<CellTypeData> res = new List<CellTypeData> ();
			res.Add (Grower);
			res.Add (Trap);
			res.Add (Lookout);
			return res;
		}
	}
}
