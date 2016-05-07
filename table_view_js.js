
$(document).ready(function () {
    $("#Submit1").click(function () {
        $.post("table_view_source.aspx",
            { table: "23e" },
        function (data) {
            $("#result").html(data);
        });
    })
})
/*
var xmlhttp;  
            //自定义函数  
            function load() {  
              //  alert("开始执行！");  
               //准备传送的数据。使用dom的方式获取文本框中的值  
             //  var userName = document.getElementById("userName").value;  
  
  
               //1、创建XMLHttpRequest对象  
               if (window.XMLHttpRequest) {  
                 //  alert("进入创建XMLHttpRequest对象的代码块！");  
                   //code for IE 7+, FireFox,Chrome,Opera,Safari  
                   xmlhttp = new XMLHttpRequest();  
                   //针对某些特定版本的mozillar浏览器的bug进行修正  
                   if (xmlhttp.overrideMineType) {  
                       xmlhttp.overrideMineType("text/xml");  
                   }                     
               }  
               //验证XMLHttpRequest对象是否创建成功  
               if (xmlhttp == undefined || xmlhttp == null) {  
                 //  alert("当前浏览器不支持创建XMLHttpRequest对象，请更换浏览器！");  
                   return;  
               }  
               //验证对象是否创建成功  
              // alert("对象创建成功！");  
  
               //2、注册回调函数  
               //注册的为函数名，不是函数名()  
               xmlhttp.onreadystatechange = callbackFunctionName;  
  
  
               //3、设置连接信息  
               //第一个参数表示http的请求方式：post和get  
               //第二个参数表示请求的url地址，get方式传送的数据在url中  
               //第三个参数表示采用异步还是同步方式交互，true表示异步  
  
               //get方法请求的代码  
             //  xmlhttp.open("GET", "B.aspx?name=" + userName, true);  
  
               ////post方式请求的代码  
               xmlhttp.open("POST", "table_view_source.aspx", true);  
               ////post方式需要自己设置http的请求头，之前浏览器会自动添加  
               xmlhttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");  
                 
  
               //4、发送数据，开始和服务器端进行交互  
               //同步方式下，send这句话会在服务器端数据回来后才执行完  
               //异步方式下，send这句话会立即完成执行  
                 
               //get方式数据的方法  
             //  xmlhttp.send(null);  
  
               ////post方式发送数据  
               xmlhttp.send("table=" + null);  
  
  
               //5、接受数据后的操作。回调函数  
               function callbackFunctionName() {  
                   //readyState：请求状态  
                   //0：未初始化；1：open方法成功调用之后；2：服务器已经应答客户端的请求；3：交互中。Http头信息已经接收，相应数据尚未接收；4：完成。数据接收完成   
                 // alert(xmlhttp.readyState);                     
                   //判断对象的状态是交互完成  
                   if (xmlhttp.readyState == 4) {  
                       //判断http的交互是否成功。200：表示成功；404表示“未找到”                       
                       if(xmlhttp.status == 200){  
                           //获取服务器端返回的数据  
                           //获取服务器端输出的纯文本数据  
                           var responseText = xmlhttp.responseText;  
                           //将数据显示在页面上  
                           //通过dom的方式找到div标签所对应的元素节点  
                           var divNode = document.getElementById("result");  
                           //设置元素节点中的html内容  
                           divNode.innerHTML = responseText;                             
                       } else{  
                           alert("出错了！！！");  
                       }  
                   }  
               }  
            }  
            */