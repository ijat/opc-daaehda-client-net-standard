/*
ScPl - A plotting library for .NET

FontScaler.cs
Copyright (C) 2003
Matt Howlett

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

1. Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
   
2. Redistributions in binary form must reproduce the following text in 
   the documentation and / or other materials provided with the 
   distribution: 
   
   "This product includes software developed as part of 
   the ScPl plotting library project available from: 
   http://www.netcontrols.org/scpl/" 

------------------------------------------------------------------------

THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

$Id: FontScaler.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;

namespace scpl
{
	/// <summary>
	/// Summary description for FontScaler.
	/// </summary>
	public class FontScaler
	{
		public static Font scaleFont( Font initial, double scale )
		{
			FontStyle fs = initial.Style;
			GraphicsUnit gu = initial.Unit;
			double sz = initial.Size;
			sz = sz * scale ;
			string nm = initial.Name;
			return new Font( nm, (float)sz, fs, gu );
		}
	}
}
