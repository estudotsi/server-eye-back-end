﻿using server_eye_back_end.Models;

namespace server_eye_back_end.Services.Interfaces
{
	public interface IAppService
	{
		List<App> ReadApps();
		App ReadAppById(int Id);
		App AddApp(App app);
	}
}
