using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace KeyAuth;

public static class encryption
{
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr GetCurrentProcess();

	public static string HashHMAC(string enckey, string resp)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(enckey);
		byte[] bytes2 = Encoding.UTF8.GetBytes(resp);
		HMACSHA256 hMACSHA = new HMACSHA256(bytes);
		return byte_arr_to_str(hMACSHA.ComputeHash(bytes2));
	}

	public static string byte_arr_to_str(byte[] ba)
	{
		StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
		foreach (byte b in ba)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		return stringBuilder.ToString();
	}

	public static byte[] str_to_byte_arr(string hex)
	{
		try
		{
			int length = hex.Length;
			byte[] array = new byte[length / 2];
			for (int i = 0; i < length; i += 2)
			{
				array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return array;
		}
		catch
		{
			api.error("The session has ended, open program again.");
			TerminateProcess(GetCurrentProcess(), 1u);
			return null;
		}
	}

	public static string iv_key()
	{
		return Guid.NewGuid().ToString().Substring(0, 16);
	}
}
