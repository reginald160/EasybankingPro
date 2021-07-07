using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Application.Core.HelperClass
{

	public  static class FileUtility
	{
		/// <summary>Replaces all invalid filename characters with underscore.</summary>
		/// <param name="name">file name</param>
		/// <returns>Valid file name</returns>
		public static string NormalizeFileName(string name)
		{
			var search = new[] { '\\', '/', ':', '*', '?', '"', '|', '\'', '<', '>', ' ' };

			return search.Aggregate(name, (current, t) => current.Replace(t, '_'));
		}

		public static void Rename(string filePath, string newFilePath, bool overwriteIfExists = false)
		{
			if (overwriteIfExists && File.Exists(newFilePath))
				File.Delete(newFilePath);

			File.Move(filePath, newFilePath);
		}
	
		public static string Upload(IFormFile model, string foldername, string webRootPath)
		{
			var uploadDir = foldername;
			var fileName = Path.GetFileNameWithoutExtension(model.FileName);
			var extension = Path.GetExtension(model.FileName);
			fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
			var path = Path.Combine(webRootPath, uploadDir, fileName);
			using (var fileStream = new FileStream(path, FileMode.Create))
			{
				model.CopyToAsync(fileStream);

			}
			string imageUrl = "/" + uploadDir + "/" + fileName;

			return imageUrl;
		}

		public static void Move(string source, string destination, bool overwriteExisting = true)
		{
			var dir = Path.GetDirectoryName(destination);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			if (overwriteExisting && File.Exists(destination))
				File.Delete(destination);

			File.Move(source, destination);
		}

		public static void CreateText(string filePaht, string content)
		{
			var dir = Path.GetDirectoryName(filePaht);
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);

			using (var sw = File.CreateText(filePaht))
			{
				sw.Write(content);
			}
		}

		public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs = true, List<string> skipfiles = null, Action<string> onFileResult = null)
		{
			// Get the subdirectories for the specified directory.
			var dir = new DirectoryInfo(sourceDirName);
			var dirs = dir.GetDirectories();

			if (!dir.Exists)
				throw new DirectoryNotFoundException("Source directory does not exist or could not be found: " + sourceDirName);

			// If the destination directory doesn't exist, create it. 
			if (!Directory.Exists(destDirName))
				Directory.CreateDirectory(destDirName);

			// Get the files in the directory and copy them to the new location.
			foreach (var file in dir.GetFiles())
			{
				if (skipfiles != null && skipfiles.Select(x => x.ToLower()).Contains(file.Name.ToLower()))
					continue;

				var temppath = Path.Combine(destDirName, file.Name);
				onFileResult?.Invoke($"Copy {file.FullName} to {temppath}");

				file.CopyTo(temppath, true);
			}

			// If copying subdirectories, copy them and their contents to new location. 
			if (!copySubDirs)
				return;

			foreach (var subdir in dirs)
			{
				var temppath = Path.Combine(destDirName, subdir.Name);
				DirectoryCopy(subdir.FullName, temppath, skipfiles: skipfiles, onFileResult: onFileResult);
			}
		}

		public static List<string> ListFilesByPattern(string dirName, string pattern, bool ifSort = false)
		{
			var dir = new DirectoryInfo(dirName);
			var files = dir.GetFiles(pattern).Select(file => file.Name).ToList();

			if (ifSort)
				files.Sort();

			return files;
		}

		public static void VerifyDirectory(string dir)
		{
			if (!Directory.Exists(dir))
				Directory.CreateDirectory(dir);
		}

		public static void RemoveDirectory(string destination)
		{
			if (Directory.Exists(destination))
				Directory.Delete(destination, true);
		}

		public static bool IsDirectoryEmpty(string path)
		{
			var directory = new DirectoryInfo(path);
			var files = directory.GetFiles();
			var subdirs = directory.GetDirectories();

			return (files.Length == 0 && subdirs.Length == 0);
		}

		public static bool DriveExists(string path)
		{
			var pathRoot = Path.GetPathRoot(path);
			if (String.IsNullOrEmpty(pathRoot))
				return false;

			pathRoot = pathRoot.ToUpper();

			return DriveInfo.GetDrives().Any(d => d.DriveType == DriveType.Fixed && d.Name.ToUpper() == pathRoot);
		}

		public static string LoadFileContents(string filePath)
		{
			return File.Exists(filePath)
				? File.ReadAllText(filePath)
				: null;
		}

		public static void SelfCopy(string destination)
		{
			var exePath = Process.GetCurrentProcess().MainModule.FileName;
			File.Copy(exePath, destination);
		}

		public static string GetAppVersion(string filepath = null)
		{
			if (filepath == null)
				filepath = Process.GetCurrentProcess().MainModule.FileName;

			var myFileVersionInfo = FileVersionInfo.GetVersionInfo(filepath);
			return myFileVersionInfo.FileVersion;
		}
	}
}
