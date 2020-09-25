#version 440 core

out vec4 outputColor;

layout (location = 9) uniform int size;
layout (location = 10) uniform vec3 Lights[100];

layout (location = 4) uniform mat4 Projection;
layout (location = 6) uniform mat4 camera;

in vec2 texCoord;
in vec4 positionn;

uniform sampler2D texture0;

float calcDistance(vec4 pos)
{
    float lighting = 0;
    for (int i = 0 ; i < size; i++)
    {
        vec4 LightPositions = Projection * camera * vec4(Lights[i].x, Lights[i].y, 1 ,1);
        lighting += (Lights[i].z) / (pow(distance(pos, LightPositions), 2));
    }
    return lighting;
} 

void main()
{
    vec4 light = vec4(1, 1, 1, 1) * calcDistance(positionn);
    vec4 d = texture(texture0, texCoord) * vec4(light.x, light.y, light.z, 1.0);
    outputColor = vec4(min(1.0, d.x), min(1.0, d.y), min(1.0, d.z), d.a);
}