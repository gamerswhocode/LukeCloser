// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
namespace AssemblyCSharp
{
	public class DialogMaster
	{
		private static readonly DialogMaster instance = new DialogMaster();

		static DialogMaster()
		{
		}

		private DialogMaster ()
		{
		}

		public static DialogMaster Instance
		{
			get
			{
				return instance;
			}
		}

		public void StartDialog(object sender, List<String> e)
		{
			DialogStarted(sender, e);
		}

		public void EndDialog(object sender, List<String> e)
		{
			DialogEnded (sender, e);
		}

		public event DialogStartedHandler DialogStarted;
		public event DialogEndedHandler DialogEnded;

			
	}
}

