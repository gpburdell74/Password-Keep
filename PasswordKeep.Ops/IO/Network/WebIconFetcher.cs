using System.Drawing;
using System.Net;

namespace PasswordKeep.Ops.IO.Network
{
	/// <summary>
	/// Provides static methods / Functions for retrieving icons and images from web sources.
	/// </summary>
	public static class WebIconFetcher
	{
		#region Private Constants		
		/// <summary>
		/// The short cut icon name.
		/// </summary>
		private const string ShortCutHtml = "shortcut icon";
		/// <summary>
		/// The relative HTML name/text.
		/// </summary>
		private const string RelHtml = "rel=\"icon";
		#endregion

		#region Public Static Methods / Functions
		/// <summary>
		/// Attempts to download the appropriate site icon or image based on the provided URL.
		/// </summary>
		/// <param name="url">
		/// A string containing the URL value.
		/// </param>
		/// <returns>
		/// The downloaded <see cref="Image"/> if successful; otherwise, returns <b>null</b>.
		/// </returns>
		public static async Task<Image?> FetchIconImageAsync(string url)
		{
			Image? bmp = null;

			if (!string.IsNullOrEmpty(url))
			{
				string? fixedUrl = FixUrl(url);
				if (fixedUrl != null)
				{
					// Try reading the favicon.ico file from the main page.
					bmp = await TryReadingFavIconAsync(fixedUrl).ConfigureAwait(false);

					if (bmp == null)
					{
						// Read the page header to determine the location of the specified Icon resource.
						bmp = await TryMainSiteAsync(fixedUrl).ConfigureAwait(false);
					}
				}
			}
			return bmp;
		}
		#endregion

		#region Private Static Methods / Functions
		/// <summary>
		/// Extracts the scheme and host name from the provided URL text.
		/// </summary>
		/// <param name="originalUrl">
		/// A string containing the original URL value.
		/// </param>
		/// <returns>
		/// A string with the scheme and host name,  or <b>null</b>.
		/// </returns>
		private static string? FixUrl(string originalUrl)
		{
			originalUrl = originalUrl.ToLower().Trim();

			// Add the HTTP:// scheme if it was not specified.
			if (!originalUrl.Contains("http://") &&
				!originalUrl.Contains("https://"))
				originalUrl = "http://" + originalUrl;

			// Try to create the URI object.
			Uri? uri;
			try
			{
				uri = new Uri(originalUrl);
			}
			catch
			{
				uri = null;
			}

			if (uri == null)
				return null;
			else
				return uri.Scheme + "://" + uri.Host;
		}
		/// <summary>
		/// Attempts to download the image from the standard /favicon.ico link.
		/// </summary>
		/// <param name="url">
		///  A string containing the URL to access.
		/// </param>
		/// <returns>
		/// The downloaded <see cref="Image"/>, if successful; otherwise, returns <b>null</b>.
		/// </returns>
		private static async Task<Image?> TryReadingFavIconAsync(string url)
		{
			Image? webImage = null;

			HttpClient? request = TryCreateRequest(url + "/favicon.ico");
			if (request != null)
			{
				HttpResponseMessage? response = null;
				try
				{
					request.Timeout = new TimeSpan(0, 0, 1);
					response = await request.GetAsync(url + "/favicon.ico").ConfigureAwait(false);
				}
				catch (Exception ex)
				{
					request.CancelPendingRequests();
					request.Dispose();
					response = null;
				}

				if (response != null)
				{
					webImage = await ReadImageFromResponseAsync(response).ConfigureAwait(false);
					response.Dispose();
				}
			}

			return webImage;
		}
		/// <summary>
		/// Attempts to download the image by parsing the header items in the main page HTML to find the image
		/// link.
		/// </summary>
		/// <param name="url">
		///  A string containing the URL to access.
		/// </param>
		/// <returns>
		/// The downloaded <see cref="Image"/>, if successful; otherwise, returns <b>null</b>.
		/// </returns>
		private static async Task<Image?> TryMainSiteAsync(string url)
		{
			Image? bmp = null;
			string? htmlContent = null;

			HttpClient? request = TryCreateRequest(url);
			if (request != null)
			{
				HttpResponseMessage? response = null;
				try
				{
					request.Timeout = new TimeSpan(0, 0, 10);
					response = await request.GetAsync(url).ConfigureAwait(false);
				}
				catch (Exception ex)
				{
					request.CancelPendingRequests();
					request.Dispose();
					response = null;
				}

				if (response != null)
				{
					htmlContent = await ReadHtmlFromResponseAsync(response).ConfigureAwait(false);
					response.Dispose();
				}
			}

			if (htmlContent != null)
			{
				string subUrl = LocateAndParseSubUrl(htmlContent);
				if (subUrl != null)
				{
					if (subUrl[0] != '/' && url[url.Length - 1] != '/')
						url = url + "/" + subUrl;
					else
						url = url + subUrl;

					request = TryCreateRequest(url);
					if (request != null)
					{
						HttpResponseMessage? response = null;
						try
						{
							request.Timeout = new TimeSpan(0, 0, 10);
							response = await request.GetAsync(url).ConfigureAwait(false);
						}
						catch (Exception ex)
						{
							request.CancelPendingRequests();
							request.Dispose();
							response = null;
						}

						if (response != null)
						{
							bmp = await ReadImageFromResponseAsync(response).ConfigureAwait(false);
							response.Dispose();
						}
						try
						{
							request.CancelPendingRequests();
						}
						catch(Exception ex)
						{
						}

						request.Dispose();
						request = null;
					}
				}
			}

			return bmp;
		}
		/// <summary>
		/// Attempts to create the request object.
		/// </summary>
		/// <param name="url">
		///  A string containing the URL to access.
		/// </param>
		/// <returns>
		/// The <see cref="HttpClient"/> instance if successful; otherwise, returns <b>null</b>.
		/// </returns>
		private static HttpClient? TryCreateRequest(string url)
		{
			HttpClient? request = null;
			try
			{
				request = new HttpClient();
				request.BaseAddress = new Uri(url);	
			}
			catch
			{
			}

			return request;
		}
		/// <summary>
		/// Reads the image from the provided web response.
		/// </summary>
		/// <param name="response">
		/// The <see cref="WebResponse"/> instance containing the stream to read from.
		/// </param>
		/// <returns>
		/// An <see cref="Image"/> containing the downloaded image if successful; otherwise,
		/// returns <b>null</b>.
		/// </returns>
		private static async Task<Image?> ReadImageFromResponseAsync(HttpResponseMessage response)
		{
			Image? image = null;
			byte[]? data = null;
			Stream? myStream = null;

			await Task.Yield();

			// Attempt to attach to the response stream.
			try
			{
				myStream = await response.Content.ReadAsStreamAsync();
			}
			catch
			{
			}

			// The image data storage stream.
			MemoryStream? imageStream = null;

			if (myStream != null)
			{
				BinaryReader reader = new BinaryReader(myStream);
				imageStream = new MemoryStream();
				bool error = false;
				do
				{
					try
					{
						// Read up to 20 MB.
						data = reader.ReadBytes(20971520);
						if (data.Length > 0)
						{
							await imageStream.WriteAsync(data, 0, data.Length).ConfigureAwait(false);
							await imageStream.FlushAsync().ConfigureAwait(false);
						}
					}
					catch
					{
						error = true;
					}
				} while (data != null && data.Length > 0 && !error);

				reader.Dispose();
				myStream.Dispose();
			}

			// Convert To an Image, if possible.
			if (imageStream != null)
			{
				try
				{
					imageStream.Seek(0, SeekOrigin.Begin);
					image = Image.FromStream(imageStream);
				}
				catch (Exception ex)
				{
				}
			}

			return image;
		}
		/// <summary>
		/// Reads the HTML text from the provided web response.
		/// </summary>
		/// <param name="response">
		/// The <see cref="WebResponse"/> instance containing the stream to read from.
		/// </param>
		/// <returns>
		/// A string containing the downloaded HTML text if successful; otherwise,
		/// returns <b>null</b>.
		/// </returns>
		private static async Task<string?> ReadHtmlFromResponseAsync(HttpResponseMessage response)
		{
			string? html = null;
			Stream? myStream = null;

			// Attempt to attach to the response stream.
			try
			{
				myStream = await response.Content.ReadAsStreamAsync();
			}
			catch
			{
			}

			if (myStream != null)
			{
				StreamReader reader = new StreamReader(myStream);
				try
				{
					html = await reader.ReadToEndAsync().ConfigureAwait(false);
				}
				catch
				{
				}

				reader.Dispose();
				myStream.Dispose();
			}

			return html;
		}
		/// <summary>
		/// Locates the and parses the image sub URL in the provided HTML.
		/// </summary>
		/// <param name="htmlContent">A string containing the HTML text.
		/// </param>
		/// <returns>
		/// A string containing the sub URL for the image, if present.
		/// </returns>
		private static string LocateAndParseSubUrl(string htmlContent)
		{
			string subUrl = null;
			// Try to find the "shortcut icon" link tag.

			int shortCutIconIndex = htmlContent.IndexOf(ShortCutHtml, StringComparison.InvariantCultureIgnoreCase);
			int relIconIndex = htmlContent.IndexOf(RelHtml, StringComparison.InvariantCultureIgnoreCase);

			// Parse the content based on which index is found.
			if (shortCutIconIndex > -1)
				subUrl = ParseShortCutIcon(htmlContent, shortCutIconIndex);
			else if (relIconIndex > -1)
				subUrl = ParseRelIcon(htmlContent, relIconIndex);

			return subUrl;
		}
		private static string? ParseShortCutIcon(string html, int startIndex)
		{
			string? subUrl = null;

			// Find the "href" attribute following the "shortcut icon".
			int hrefIndex = html.IndexOf("href=", startIndex + 15, StringComparison.InvariantCultureIgnoreCase);
			if (hrefIndex > -1)
			{
				// Find the next quote mark.
				int nextIndex = html.IndexOf("\"", hrefIndex + 6, StringComparison.InvariantCultureIgnoreCase);
				if (nextIndex > -1)
				{
					subUrl = html.Substring(hrefIndex + 6, nextIndex - (hrefIndex + 6));
				}
			}

			return subUrl;
		}
		private static string? ParseRelIcon(string html, int startIndex)
		{
			string? subUrl = null;

			// Remove the preceding text.
			string remaining = html.Substring(startIndex, html.Length - (startIndex + 12)).Trim();

			// Find the next href attribute.
			int hrefIndex = remaining.IndexOf("href=", StringComparison.InvariantCultureIgnoreCase);
			if (hrefIndex > -1)
			{
				// Extract the value in the href attribute.
				int outer = remaining.IndexOf("\"", hrefIndex + 5,
					StringComparison.InvariantCultureIgnoreCase);
				int inner = remaining.IndexOf("\"", outer + 1, StringComparison.InvariantCultureIgnoreCase);
				subUrl = remaining.Substring(outer + 1, inner - (outer + 1));
			}

			return subUrl;
		}
		#endregion
	}
}