#version 440 core

layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec2 aTexCoord;
layout (location = 4) uniform mat4 Projection;
layout (location = 5) uniform mat4 ModelView;
layout (location = 6) uniform mat4 camera;

layout (location = 9) uniform int size;

layout (location = 10) uniform vec3 Lights[100];

//layout (location = 6) uniform float ambientStrength;
//layout (location = 7) uniform vec3 ambientColor;

out vec2 texCoord;
out vec4 positionn;

void main(void)
{
    texCoord = aTexCoord;
    vec4 pos = Projection * camera * ModelView * vec4(aPosition, 1.0);
    positionn = pos;
    gl_Position = pos;
}