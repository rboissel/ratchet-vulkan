#version 450
#extension GL_ARB_separate_shader_objects : enable

out gl_PerVertex {
    vec4 gl_Position;
};

vec3 triangle[3] = vec3[]
(
    vec3(0.0, -0.5, 0.0),
    vec3(0.5, 0.5, 0.0),
    vec3(-0.5, 0.5, 0.0)
);

void main()
{
    gl_Position = vec4(triangle[gl_VertexIndex], 1.0);
}
