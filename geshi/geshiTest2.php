<?

//
// Include the GeSHi library
//
include_once('geshi.php');

$source="G://ClassFolders//OOP//pub//classsource//hello.cs";

$filename = $source;
$handle = fopen($filename, "rb");
$contents = fread($handle, filesize($filename));

$language="csharp";
$path="geshi";

// Simply echo the highlighted code
geshi_highlight($contents, $language , $path);

//$geshi = new GeSHi($source, $language);

//
// And echo the result!
//
//echo $geshi->parse_code();

?>