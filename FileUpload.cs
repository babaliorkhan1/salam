namespace Doggie.Extensions
{
    public static class FileUpload
    {

        public static string CreateImage(this IFormFile file, string root, string path)
        {
            string FileName = Guid.NewGuid().ToString() + file.FileName;
            string FullPath = Path.Combine(root, path, FileName);
            using (FileStream fileStream = new FileStream(FullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return FileName;
        }


        public static string CreateVideo(this IFormFile formFile,string root,string path)
        {
            string uploadsFolder=Path.Combine(root,path);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);

            }

            string fileName=Path.GetFileName(formFile.FileName);    
            string fileSavePath=Path.Combine(uploadsFolder,fileName);


            using (FileStream stream=new FileStream(fileSavePath, FileMode.Create))
            {
                formFile.CopyTo(stream);
            }
            return fileName;
			
			
		}

		//[HttpGet]
		//public IActionResult Index1()
		//{



		//	return View();
		//}
		//[HttpPost]
		////[ValidateAntiForgeryToken]
		//public IActionResult Index1(IFormFile FormFile)
		//{


		//	//formFile.CreateVideo(_env.WebRootPath,"assets/videos");
		//	string uploadsFolder = Path.Combine(_env.WebRootPath, "assets/videoss");

		//	if (!Directory.Exists(uploadsFolder))
		//	{
		//		Directory.CreateDirectory(uploadsFolder);

		//	}

		//	string fileName = Path.GetFileName(FormFile.FileName);
		//	string fileSavePath = Path.Combine(uploadsFolder, fileName);


		//	using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
		//	{
		//		FormFile.CopyTo(stream);
		//	}


		//	return RedirectToAction(nameof(Index));
		//}
	}
}
