# creates build/html
rm -r build -errorAction ignore
$d = mkdir build
$d = mkdir build/html
cp -r WebSharper.MaterialUI.Tests/Content build/html/
cp -r WebSharper.MaterialUI.Tests/*.jpg build/html/
cp -r WebSharper.MaterialUI.Tests/*.css build/html/
cp -r WebSharper.MaterialUI.Tests/*.html build/html/
