<?php
	function GetFiles($directory)
	{
		$files = array();
		if (is_dir($directory))
		{
			if ($handle = opendir($directory))
			{
				while ($file = readdir($handle)) 
				{
					if (!is_dir($directory . '\\' . $file))
						array_push($files, $file);
				}
				closedir($handle);
			}
		}
		return $files;
	}
	
	function GetDirectories($directory)
	{
		$directories = array();
		if (is_dir($directory))
		{
			if ($handle = opendir($directory))
			{
				while (($file = readdir($handle)) !== false) 
				{
					if (is_dir($directory . '\\' . $file))
						array_push($directories, $file);
				}
				closedir($handle);
			}
		}
		return $directories;
	}
	
	function GetFileContents($file)
	{
		$handle = fopen($file, "r");
		$contents = '';
		if (filesize($file) != 0)
			$contents = fread($handle, filesize($file));
		fclose($handle);
		return $contents;
	}
?>