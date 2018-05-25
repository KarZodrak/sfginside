Shader "Custom/GreyRedScale" {
 Properties {
     _MainTex ("Base (RGB)", 2D) = "white" {}
     _RedPower ("Red Power", Range(0.001,1.0)) = 1.0
     _RedDelta ("Red Delta", Range(0.001,1.0)) = 1.0
 }
 SubShader {
     Tags { "RenderType"="Opaque" }
     LOD 200
     
     CGPROGRAM
     #pragma surface surf Lambert

     sampler2D _MainTex;
     float _RedPower;
     float _RedDelta;

     struct Input {
         float2 uv_MainTex;
     };

     void surf (Input IN, inout SurfaceOutput o) {
         half4 c = tex2D (_MainTex, IN.uv_MainTex);
         
         half avg = c.r + c.g + c.b;
         avg *= 0.333;
         half4 nC = half4(avg,avg,avg,c.a);
         
         half avg2 = c.g+c.b;
         avg2 *= 0.5;
         
         if(c.r > _RedPower && (c.r - avg2) > _RedDelta)
         {                
             nC.rgb = half3(c.r,avg2,avg2);
         }
         
         o.Albedo = nC.rgb;
         o.Alpha = c.a;
     }
     ENDCG
 } 
 FallBack "Diffuse"
}