<?

//
// Include the GeSHi library
//
include_once('geshi.php');

//$file='//classsource//hello.cs';

$file= $_GET['file'];
$file= str_replace(".." , "" , $file);
echo ("<span>" . $file ."</span> &nbsp; <a href='javascript:history.back(1)'>Source Browser</a>");

$source = dirname(__FILE__).$file;

//$source="G:\\user\\ARyou\\pub\\oop\\browser\\broswer.aspx.cs";
//echo($source);

$filename = $source;
if (!($handle = fopen($filename, "rb")) )
    die("Sorry could not open handle");
if (! ($contents = fread($handle, filesize($filename) ) ) ) {
    die("Sorry could not read file");
}

//echo("file:<pre>" . $contents . "</pre>");

$language='csharp';
if ( isset($_GET['lang']) ) {
    $language= $_GET['lang'];
}

$path="geshi";

// Simply echo the highlighted code
//geshi_highlight($contents, $language , $path);

$geshi = new GeSHi($contents, $language, $path);
//$geshi->load_from_file(str_replace("/" , "" , $file));

if ($geshi->error)   // GeSHi could not find the language, nothing to do
    return;

//$geshi->set_overall_style('color: #000066; border: 1px solid #d0d0d0; background-color: #f0f0f0;', true);


// do syntax-highlighting
  //$geshi->set_encoding($element->texy->utf ? 'UTF-8' : 'ISO-8859-1');
//  $geshi->set_header_type(GESHI_HEADER_PRE);
  $geshi->enable_classes();
  $geshi->set_overall_style('color: #000066; border: 1px solid #d0d0d0; background-color: #f0f0f0;', true);
  $geshi->set_line_style('font: normal normal 95% \'Courier New\', Courier, monospace; color: #003030;', 'font-weight: bold; color: #006060;', true);
  $geshi->set_code_style('color: #000020;', 'color: #000020;');
  $geshi->set_link_styles(GESHI_LINK, 'color: #000060;');
  $geshi->set_link_styles(GESHI_HOVER, 'background-color: #f0f000;');
  if(!($_GET['line'] = 'no'))
    $geshi->enable_line_numbers(GESHI_NORMAL_LINE_NUMBERS);

//
// And echo the result!
//


echo $geshi->parse_code();

?>