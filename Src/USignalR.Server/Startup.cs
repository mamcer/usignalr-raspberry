﻿using Owin;
using Microsoft.Owin.Cors;

public class Startup
{
	public void Configuration(IAppBuilder app)
	{
		app.UseCors(CorsOptions.AllowAll);
		app.MapSignalR();
	}
}