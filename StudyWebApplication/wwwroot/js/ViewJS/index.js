//$("#button1").on("click", function()
//{
//    $("#list1").append("<li>테스트4</li>");
//    $("#div1").css("background-color", "red");
//    console.log($("#div1"));
//    $.ajax({
//        url: "/Note/Test",
//        //url: "/Note/Test",
//        type: "POST",
//        success: function(result)
//        {
//            var str = new String(result).split(",");
//            var result = "";

//            for(var i = 0; i < str.length; i++)
//            {
//                result += `<h1>text${i} : ${str[i]} </h1>`;
//            }

//            $("#result1").html(result);
//        }
//    })
//});

$("#button1").on({
    click: () =>
    {
        console.log($(".container").children("a").first().css("font-family"));
        //$("#div1").css({ "color": "blue", "background-color": "red", "font-size": "20px" });

        //$("#text").text("마우스 클릭");
    }
})

function rgb2hex(rgb)
{
    rgb = rgb.match(/^rgba?\((\d+),\s*(\d+),\s*(\d+)(?:,\s*(\d+))?\)$/);

    function hex(x)
    {
        return ("0" + parseInt(x).toString(16)).slice(-2);
    }

    return "#" + hex(rgb[1]) + hex(rgb[2]) + hex(rgb[3]);
}