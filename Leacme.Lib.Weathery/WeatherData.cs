using System;
using System.Collections.Generic;

namespace Leacme.Lib.Weathery {
	public class WeatherData {
		public string Ver { get; set; }
		public Head Head { get; set; }
		public Loc Loc { get; set; }
		public Swa Swa { get; set; }
		public Dayf Dayf { get; set; }
	}


	public class Dayf {
		public string Lsup { get; set; }
		public List<Day> Day { get; set; }
	}

	public class Day {
		public long D { get; set; }
		public string T { get; set; }
		public string Dt { get; set; }
		public long Hi { get; set; }
		public long Low { get; set; }
		public string Sunr { get; set; }
		public string Suns { get; set; }
		public List<Part> Part { get; set; }
	}

	public class Part {
		public string P { get; set; }
		public string Icon { get; set; }
		public string T { get; set; }
		public Wind Wind { get; set; }
		public string Bt { get; set; }
		public long Ppcp { get; set; }
		public long Hmid { get; set; }
	}

	public class Wind {
		public string S { get; set; }
		public string Gust { get; set; }
		public long D { get; set; }
		public string T { get; set; }
	}

	public class Head {
		public string Locale { get; set; }
		public string Form { get; set; }
		public string Ut { get; set; }
		public string Ud { get; set; }
		public string Us { get; set; }
		public string Up { get; set; }
		public string Ur { get; set; }
	}

	public class Loc {
		public string Id { get; set; }
		public string Dnam { get; set; }
		public string Tm { get; set; }
		public string Lat { get; set; }
		public string Lon { get; set; }
		public string Sunr { get; set; }
		public string Suns { get; set; }
		public long Zone { get; set; }
	}

	public class Swa {
		public A A { get; set; }
	}

	public class A {
		public Guid Id { get; set; }
		public long Uc { get; set; }
		public string T { get; set; }
		public Uri L { get; set; }
	}


}