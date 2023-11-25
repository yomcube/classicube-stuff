# ClassiCube Plugin API Docs

Plugin API version: 1

These are the functions that are marked available for use in plugins. Note that the following are only the functions, not the macros, structs, or anything else provided in the headers.

## Table of Contents

- [Bitmap.h](#bitmaph)
- [Block.h](#blockh)
- [Camera.h](#camerah)
- [Chat.h](#chath)
- [Deflate.h](#deflateh)
- [Drawer2D.h](#drawer2dh)
- [Drawer.h](#drawerh)
- [Entity.h](#entityh)
- [Event.h](#eventh)
- [ExtMath.h](#extmathh)
- [Formats.h](#formatsh)
- [Game.h](#gameh)
- [Graphics.h](#graphicsh)
- [Gui.h](#guih)
- [Input.h](#inputh)
- [Model.h](#modelh)
- [Options.h](#optionsh)
- [PackedCol.h](#packedcolh)
- [Physics.h](#physicsh)
- [Platform.h](#platformh)
- [Protocol.h](#protocolh)
- [SelectionBox.h](#selectionboxh)
- [Stream.h](#streamh)
- [String.h](#stringh)
- [SystemFonts.h](#systemfontsh)
- [TexturePack.h](#texturepackh)
- [Vectors.h](#vectorsh)
- [Window.h](#windowh)
- [World.h](#worldh)

## [Bitmap.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Bitmap.h)

```c
void Bitmap_Scale (struct Bitmap* dst, struct Bitmap* src, int srcX, int srcY, int srcWidth, int srcHeight)
```

```c
cc_result Png_Decode (struct Bitmap* bmp, struct Stream* stream)
```

## [Block.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Block.h)

```c
cc_string Block_UNSAFE_GetName (BlockID block)
```

```c
int Block_FindID (const cc_string* name)
```

```c
int Block_Parse (const cc_string* name)
```

## [Camera.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Camera.h)

```c
void Camera_Register (struct Camera* camera)
```

## [Chat.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Chat.h)

```c
void Commands_Register (struct ChatCommand* cmd)
```

```c
void Chat_Send (const cc_string* text, cc_bool logUsage)
```

```c
void Chat_Add (const cc_string* text)
```

```c
void Chat_AddOf (const cc_string* text, int msgType)
```

## [Deflate.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Deflate.h)

```c
void Inflate_Init2 (struct InflateState* state, struct Stream* source)
```

```c
void Inflate_MakeStream2 (struct Stream* stream, struct InflateState* state, struct Stream* underlying)
```

```c
void Deflate_MakeStream (struct Stream* stream, struct DeflateState* state, struct Stream* underlying)
```

```c
void GZip_MakeStream (struct Stream* stream, struct GZipState* state, struct Stream* underlying)
```

```c
void ZLib_MakeStream (struct Stream* stream, struct ZLibState* state, struct Stream* underlying)
```

```c
cc_result Zip_Extract (struct Stream* source, Zip_SelectEntry selector, Zip_ProcessEntry processor)
```

## [Drawer2D.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Drawer2D.h)

```c
void Context2D_Alloc (struct Context2D* ctx, int width, int height)
```

```c
void Context2D_Wrap (struct Context2D* ctx, struct Bitmap* bmp)
```

```c
void Context2D_Free (struct Context2D* ctx)
```

```c
void Context2D_MakeTexture (struct Texture* tex, struct Context2D* ctx)
```

```c
void Context2D_DrawText (struct Context2D* ctx, struct DrawTextArgs* args, int x, int y)
```

```c
void Context2D_DrawPixels (struct Context2D* ctx, int x, int y, struct Bitmap* src)
```

```c
void Context2D_Clear (struct Context2D* ctx, BitmapCol color, int x, int y, int width, int height)
```

```c
void Gradient_Noise (struct Context2D* ctx, BitmapCol color, int variation, int x, int y, int width, int height)
```

```c
void Gradient_Vertical (struct Context2D* ctx, BitmapCol a, BitmapCol b, int x, int y, int width, int height)
```

```c
void Gradient_Blend (struct Context2D* ctx, BitmapCol color, int blend, int x, int y, int width, int height)
```

```c
int Drawer2D_TextWidth (struct DrawTextArgs* args)
```

```c
int Drawer2D_TextHeight (struct DrawTextArgs* args)
```

```c
void Drawer2D_MakeTextTexture (struct Texture* tex, struct DrawTextArgs* args)
```

```c
void Font_Make (struct FontDesc* desc, int size, int flags)
```

```c
void Font_Free (struct FontDesc* desc)
```

## [Drawer.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Drawer.h)

```c
void Drawer_XMin (int count, PackedCol col, TextureLoc texLoc, struct VertexTextured** vertices)
```

```c
void Drawer_XMax (int count, PackedCol col, TextureLoc texLoc, struct VertexTextured** vertices)
```

```c
void Drawer_ZMin (int count, PackedCol col, TextureLoc texLoc, struct VertexTextured** vertices)
```

```c
void Drawer_ZMax (int count, PackedCol col, TextureLoc texLoc, struct VertexTextured** vertices)
```

```c
void Drawer_YMin (int count, PackedCol col, TextureLoc texLoc, struct VertexTextured** vertices)
```

```c
void Drawer_YMax (int count, PackedCol col, TextureLoc texLoc, struct VertexTextured** vertices)
```

## [Entity.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Entity.h)

```c
void Entity_GetTransform (struct Entity* e, Vec3 pos, Vec3 scale, struct Matrix* m)
```

```c
void Entity_SetModel (struct Entity* e, const cc_string* model)
```

```c
cc_bool Entity_TouchesAny (struct AABB* bb, Entity_TouchesCondition cond)
```

```c
void TabList_Remove (EntityID id)
```

```c
void TabList_Set (EntityID id, const cc_string* player, const cc_string* list, const cc_string* group, cc_uint8 rank)
```

```c
void NetPlayer_Init (struct NetPlayer* player)
```

## [Event.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Event.h)

```c
void Event_Register (struct Event_Void* handlers, void* obj, Event_Void_Callback handler)
```

```c
void Event_Unregister (struct Event_Void* handlers, void* obj, Event_Void_Callback handler)
```

```c
void Event_RaiseVoid (struct Event_Void* handlers)
```

```c
void Event_RaiseInt (struct Event_Int* handlers, int arg)
```

```c
void Event_RaiseFloat (struct Event_Float* handlers, float arg)
```

## [ExtMath.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/ExtMath.h)

```c
double Math_Sin (double x)
```

```c
double Math_Cos (double x)
```

```c
void Random_Seed (RNGState* rnd, int seed)
```

```c
int Random_Next (RNGState* rnd, int n)
```

```c
float Random_Float (RNGState* rnd)
```

## [Formats.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Formats.h)

```c
void MapImporter_Register (struct MapImporter* imp)
```

```c
struct MapImporter* MapImporter_Find (const cc_string* path)
```

```c
cc_result Map_LoadFrom (const cc_string* path)
```

## [Game.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Game.h)

```c
void Game_UpdateBlock (int x, int y, int z, BlockID block)
```

```c
void Game_ChangeBlock (int x, int y, int z, BlockID block)
```

```c
int ScheduledTask_Add (double interval, ScheduledTaskCallback callback)
```

## [Graphics.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Graphics.h)

```c
GfxResourceID Gfx_CreateTexture (struct Bitmap* bmp, cc_uint8 flags, cc_bool mipmaps)
```

```c
void Gfx_UpdateTexturePart (GfxResourceID texId, int x, int y, struct Bitmap* part, cc_bool mipmaps)
```

```c
void Gfx_BindTexture (GfxResourceID texId)
```

```c
void Gfx_DeleteTexture (GfxResourceID* texId)
```

```c
void Gfx_SetTexturing (cc_bool enabled)
```

```c
void Gfx_EnableMipmaps (void)
```

```c
void Gfx_DisableMipmaps (void)
```

```c
cc_bool Gfx_GetFog (void)
```

```c
void Gfx_SetFog (cc_bool enabled)
```

```c
void Gfx_SetFogCol (PackedCol col)
```

```c
void Gfx_SetFogDensity (float value)
```

```c
void Gfx_SetFogEnd (float value)
```

```c
void Gfx_SetFogMode (FogFunc func)
```

```c
void Gfx_SetFaceCulling (cc_bool enabled)
```

```c
void Gfx_SetAlphaTest (cc_bool enabled)
```

```c
void Gfx_SetAlphaBlending (cc_bool enabled)
```

```c
void Gfx_SetAlphaArgBlend (cc_bool enabled)
```

```c
void Gfx_Clear (void)
```

```c
void Gfx_ClearCol (PackedCol col)
```

```c
void Gfx_SetDepthTest (cc_bool enabled)
```

```c
void Gfx_SetColWriteMask (cc_bool r, cc_bool g, cc_bool b, cc_bool a)
```

```c
void Gfx_SetDepthWrite (cc_bool enabled)
```

```c
void Gfx_DepthOnlyRendering (cc_bool depthOnly)
```

```c
GfxResourceID Gfx_CreateIb2 (int count, Gfx_FillIBFunc fillFunc, void* obj)
```

```c
void Gfx_BindIb (GfxResourceID ib)
```

```c
void Gfx_DeleteIb (GfxResourceID* ib)
```

```c
GfxResourceID Gfx_CreateVb (VertexFormat fmt, int count)
```

```c
void Gfx_BindVb (GfxResourceID vb)
```

```c
void Gfx_DeleteVb (GfxResourceID* vb)
```

```c
void* Gfx_LockVb (GfxResourceID vb, VertexFormat fmt, int count)
```

```c
void Gfx_UnlockVb (GfxResourceID vb)
```

```c
GfxResourceID Gfx_CreateDynamicVb (VertexFormat fmt, int maxVertices)
```

```c
void Gfx_BindDynamicVb (GfxResourceID vb)
```

```c
void Gfx_DeleteDynamicVb (GfxResourceID* vb)
```

```c
void* Gfx_LockDynamicVb (GfxResourceID vb, VertexFormat fmt, int count)
```

```c
void Gfx_UnlockDynamicVb (GfxResourceID vb)
```

```c
void Gfx_SetDynamicVbData (GfxResourceID vb, void* vertices, int vCount)
```

```c
void Gfx_SetVertexFormat (VertexFormat fmt)
```

```c
void Gfx_DrawVb_Lines (int verticesCount)
```

```c
void Gfx_DrawVb_IndexedTris_Range (int verticesCount, int startVertex)
```

```c
void Gfx_DrawVb_IndexedTris (int verticesCount)
```

```c
void Gfx_LoadMatrix (MatrixType type, const struct Matrix* matrix)
```

```c
void Gfx_LoadIdentityMatrix (MatrixType type)
```

```c
void Gfx_EnableTextureOffset (float x, float y)
```

```c
void Gfx_DisableTextureOffset (void)
```

## [Gui.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Gui.h)

```c
void Gui_Remove (struct Screen* screen)
```

```c
void Gui_Add (struct Screen* screen, int priority)
```

```c
struct Screen* Gui_GetInputGrab (void)
```

## [Input.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Input.h)

```c
cc_bool KeyBind_IsPressed (KeyBind binding)
```

## [Model.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Model.h)

```c
void Model_Init (struct Model* model)
```

```c
void Model_Render (struct Model* model, struct Entity* entity)
```

```c
void Model_SetupState (struct Model* model, struct Entity* entity)
```

```c
void Model_ApplyTexture (struct Entity* entity)
```

```c
void Model_UpdateVB (void)
```

```c
void Model_DrawPart (struct ModelPart* part)
```

```c
void Model_DrawRotate (float angleX, float angleY, float angleZ, struct ModelPart* part, cc_bool head)
```

```c
void Model_DrawArmPart (struct ModelPart* part)
```

```c
struct Model* Model_Get (const cc_string* name)
```

```c
void Model_Register (struct Model* model)
```

```c
void Model_RegisterTexture (struct ModelTex* tex)
```

```c
void BoxDesc_BuildBox (struct ModelPart* part, const struct BoxDesc* desc)
```

```c
void BoxDesc_BuildRotatedBox (struct ModelPart* part, const struct BoxDesc* desc)
```

```c
void BoxDesc_XQuad (struct Model* m, int texX, int texY, int texWidth, int texHeight, float z1, float z2, float y1, float y2, float x, cc_bool swapU)
```

```c
void BoxDesc_YQuad (struct Model* m, int texX, int texY, int texWidth, int texHeight, float x1, float x2, float z1, float z2, float y, cc_bool swapU)
```

```c
void BoxDesc_ZQuad (struct Model* m, int texX, int texY, int texWidth, int texHeight, float x1, float x2, float y1, float y2, float z, cc_bool swapU)
```

```c
void BoxDesc_XQuad2 (struct Model* m, float z1, float z2, float y1, float y2, float x, int u1, int v1, int u2, int v2)
```

```c
void BoxDesc_YQuad2 (struct Model* m, float x1, float x2, float z1, float z2, float y, int u1, int v1, int u2, int v2)
```

```c
void BoxDesc_ZQuad2 (struct Model* m, float x1, float x2, float y1, float y2, float z, int u1, int v1, int u2, int v2)
```

## [Options.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Options.h)

```c
void Options_Reload (void)
```

```c
void Options_SaveIfChanged (void)
```

```c
void Options_Get (const char* key, cc_string* value, const char* defValue)
```

```c
int Options_GetInt (const char* key, int min, int max, int defValue)
```

```c
cc_bool Options_GetBool (const char* key, cc_bool defValue)
```

```c
float Options_GetFloat (const char* key, float min, float max, float defValue)
```

```c
int Options_GetEnum (const char* key, int defValue, const char* const* names, int namesCount)
```

```c
void Options_SetBool (const char* keyRaw, cc_bool value)
```

```c
void Options_SetInt (const char* keyRaw, int value)
```

```c
void Options_Set (const char* keyRaw, const cc_string* value)
```

```c
void Options_SetString (const cc_string* key, const cc_string* value)
```

## [PackedCol.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/PackedCol.h)

```c
PackedCol PackedCol_Scale (PackedCol value, float t)
```

```c
PackedCol PackedCol_Lerp (PackedCol a, PackedCol b, float t)
```

```c
PackedCol PackedCol_Tint (PackedCol a, PackedCol b)
```

## [Physics.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Physics.h)

```c
void AABB_Make (struct AABB* result, const Vec3* pos, const Vec3* size)
```

## [Platform.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Platform.h)

```c
cc_result Process_StartGame2 (const cc_string* args, int numArgs)
```

```c
void Process_Exit (cc_result code)
```

```c
cc_result Process_StartOpen (const cc_string* args)
```

```c
void* DynamicLib_Load2 (const cc_string* path)
```

```c
void* DynamicLib_Get2 (void* lib, const char* name)
```

```c
cc_bool DynamicLib_DescribeError (cc_string* dst)
```

```c
// OBSOLETE
cc_result DynamicLib_Load (const cc_string* path, void** lib)
```

```c
// OBSOLETE
cc_result DynamicLib_Get (void* lib, const char* name, void** symbol)
```

```c
void* Mem_TryAlloc (cc_uint32 numElems, cc_uint32 elemsSize)
```

```c
void* Mem_TryAllocCleared (cc_uint32 numElems, cc_uint32 elemsSize)
```

```c
void* Mem_TryRealloc (void* mem, cc_uint32 numElems, cc_uint32 elemsSize)
```

```c
void* Mem_Alloc (cc_uint32 numElems, cc_uint32 elemsSize, const char* place)
```

```c
void* Mem_AllocCleared (cc_uint32 numElems, cc_uint32 elemsSize, const char* place)
```

```c
void* Mem_Realloc (void* mem, cc_uint32 numElems, cc_uint32 elemsSize, const char* place)
```

```c
void Mem_Free (void* mem)
```

```c
TimeMS DateTime_CurrentUTC_MS (void)
```

```c
void DateTime_CurrentLocal (struct DateTime* t)
```

```c
cc_uint64 Stopwatch_Measure (void)
```

```c
cc_uint64 Stopwatch_ElapsedMicroseconds (cc_uint64 beg, cc_uint64 end)
```

```c
cc_result Directory_Create (const cc_string* path)
```

```c
cc_result Directory_Enum (const cc_string* path, void* obj, Directory_EnumCallback callback)
```

```c
int File_Exists (const cc_string* path)
```

```c
void Thread_Sleep (cc_uint32 milliseconds)
```

```c
void* Thread_Create (Thread_StartFunc func)
```

```c
void Thread_Start2 (void* handle, Thread_StartFunc func)
```

```c
void Thread_Detach (void* handle)
```

```c
void Thread_Join (void* handle)
```

```c
void* Mutex_Create (void)
```

```c
void Mutex_Free (void* handle)
```

```c
void Mutex_Lock (void* handle)
```

```c
void Mutex_Unlock (void* handle)
```

```c
void* Waitable_Create (void)
```

```c
void Waitable_Free (void* handle)
```

```c
void Waitable_Signal (void* handle)
```

```c
void Waitable_Wait (void* handle)
```

```c
void Waitable_WaitFor (void* handle, cc_uint32 milliseconds)
```

## [Protocol.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Protocol.h)

```c
void CPE_SendPluginMessage (cc_uint8 channel, cc_uint8* data)
```

## [SelectionBox.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/SelectionBox.h)

```c
void Selections_Add (cc_uint8 id, const IVec3* p1, const IVec3* p2, PackedCol color)
```

```c
void Selections_Remove (cc_uint8 id)
```

## [Stream.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Stream.h)

```c
cc_result Stream_Read (struct Stream* s, cc_uint8* buffer, cc_uint32 count)
```

```c
cc_result Stream_Write (struct Stream* s, const cc_uint8* buffer, cc_uint32 count)
```

```c
cc_result Stream_OpenFile (struct Stream* s, const cc_string* path)
```

```c
cc_result Stream_CreateFile (struct Stream* s, const cc_string* path)
```

```c
void Stream_FromFile (struct Stream* s, cc_file file)
```

```c
void Stream_ReadonlyPortion (struct Stream* s, struct Stream* source, cc_uint32 len)
```

```c
void Stream_ReadonlyMemory (struct Stream* s, void* data, cc_uint32 len)
```

```c
void Stream_ReadonlyBuffered (struct Stream* s, struct Stream* source, void* data, cc_uint32 size)
```

```c
cc_result Stream_ReadLine (struct Stream* s, cc_string* text)
```

```c
cc_result Stream_WriteLine (struct Stream* s, cc_string* text)
```

## [String.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/String.h)

```c
int String_CalcLen (const char* raw, int capacity)
```

```c
cc_string String_FromReadonly (const char* buffer)
```

```c
void String_Copy (cc_string* dst, const cc_string* src)
```

```c
void String_CopyToRaw (char* dst, int capacity, const cc_string* src)
```

```c
cc_string String_UNSAFE_Substring (const cc_string* str, int offset, int length)
```

```c
cc_string String_UNSAFE_SubstringAt (const cc_string* str, int offset)
```

```c
int String_UNSAFE_Split (const cc_string* str, char c, cc_string* subs, int maxSubs)
```

```c
void String_UNSAFE_SplitBy (cc_string* str, char c, cc_string* part)
```

```c
int String_UNSAFE_Separate (const cc_string* str, char c, cc_string* key, cc_string* value)
```

```c
int String_Equals (const cc_string* a, const cc_string* b)
```

```c
int String_CaselessEquals (const cc_string* a, const cc_string* b)
```

```c
int String_CaselessEqualsConst (const cc_string* a, const char* b)
```

```c
void String_Append (cc_string* str, char c)
```

```c
void String_AppendBool (cc_string* str, cc_bool value)
```

```c
void String_AppendInt (cc_string* str, int num)
```

```c
void String_AppendUInt32 (cc_string* str, cc_uint32 num)
```

```c
void String_AppendPaddedInt (cc_string* str, int num, int minDigits)
```

```c
void String_AppendFloat (cc_string* str, float num, int fracDigits)
```

```c
void String_AppendConst (cc_string* str, const char* src)
```

```c
void String_AppendString (cc_string* str, const cc_string* src)
```

```c
void String_AppendColorless (cc_string* str, const cc_string* src)
```

```c
void String_AppendHex (cc_string* str, cc_uint8 value)
```

```c
int String_IndexOfAt (const cc_string* str, int offset, char c)
```

```c
int String_LastIndexOfAt (const cc_string* str, int offset, char c)
```

```c
void String_InsertAt (cc_string* str, int offset, char c)
```

```c
void String_DeleteAt (cc_string* str, int offset)
```

```c
void String_UNSAFE_TrimStart (cc_string* str)
```

```c
void String_UNSAFE_TrimEnd (cc_string* str)
```

```c
int String_IndexOfConst (const cc_string* str, const char* sub)
```

```c
int String_CaselessContains (const cc_string* str, const cc_string* sub)
```

```c
int String_CaselessStarts (const cc_string* str, const cc_string* sub)
```

```c
int String_CaselessEnds (const cc_string* str, const cc_string* sub)
```

```c
int String_Compare (const cc_string* a, const cc_string* b)
```

```c
void String_Format1 (cc_string* str, const char* format, const void* a1)
```

```c
void String_Format2 (cc_string* str, const char* format, const void* a1, const void* a2)
```

```c
void String_Format3 (cc_string* str, const char* format, const void* a1, const void* a2, const void* a3)
```

```c
void String_Format4 (cc_string* str, const char* format, const void* a1, const void* a2, const void* a3, const void* a4)
```

```c
cc_bool Convert_TryCodepointToCP437 (cc_codepoint cp, char* c)
```

```c
cc_bool Convert_ParseUInt8 (const cc_string* str, cc_uint8* value)
```

```c
cc_bool Convert_ParseUInt16 (const cc_string* str, cc_uint16* value)
```

```c
cc_bool Convert_ParseInt (const cc_string* str, int* value)
```

```c
cc_bool Convert_ParseUInt64 (const cc_string* str, cc_uint64* value)
```

```c
cc_bool Convert_ParseFloat (const cc_string* str, float* value)
```

```c
cc_bool Convert_ParseBool (const cc_string* str, cc_bool* value)
```

```c
cc_string StringsBuffer_UNSAFE_Get (struct StringsBuffer* buffer, int i)
```

```c
void StringsBuffer_Add (struct StringsBuffer* buffer, const cc_string* str)
```

```c
void StringsBuffer_Remove (struct StringsBuffer* buffer, int index)
```

## [SystemFonts.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/SystemFonts.h)

```c
void SysFonts_GetNames (struct StringsBuffer* buffer)
```

## [TexturePack.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/TexturePack.h)

```c
void TexturePack_Extract (const cc_string* url)
```

## [Vectors.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Vectors.h)

```c
void Matrix_RotateX (struct Matrix* result, float angle)
```

```c
void Matrix_RotateY (struct Matrix* result, float angle)
```

```c
void Matrix_RotateZ (struct Matrix* result, float angle)
```

```c
void Matrix_Translate (struct Matrix* result, float x, float y, float z)
```

```c
void Matrix_Scale (struct Matrix* result, float x, float y, float z)
```

```c
void Matrix_Mul (struct Matrix* result, const struct Matrix* left, const struct Matrix* right)
```

## [Window.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/Window.h)

```c
void Window_SetTitle (const cc_string* title)
```

```c
void Clipboard_GetText (cc_string* value)
```

```c
void Clipboard_SetText (const cc_string* value)
```

```c
void Window_ShowDialog (const char* title, const char* msg)
```

## [World.h](https://github.com/UnknownShadow200/ClassiCube/blob/master/src/World.h)

```c
void World_NewMap (void)
```

```c
void World_SetNewMap (BlockRaw* blocks, int width, int height, int length)
```

```c
void Env_Reset (void)
```

```c
void Env_SetEdgeBlock (BlockID block)
```

```c
void Env_SetSidesBlock (BlockID block)
```

```c
void Env_SetEdgeHeight (int height)
```

```c
void Env_SetSidesOffset (int offset)
```

```c
void Env_SetCloudsHeight (int height)
```

```c
void Env_SetCloudsSpeed (float speed)
```

```c
void Env_SetWeatherSpeed (float speed)
```

```c
void Env_SetWeatherFade (float rate)
```

```c
void Env_SetWeather (int weather)
```

```c
void Env_SetExpFog (cc_bool expFog)
```

```c
void Env_SetSkyboxHorSpeed (float speed)
```

```c
void Env_SetSkyboxVerSpeed (float speed)
```

```c
void Env_SetSkyCol (PackedCol color)
```

```c
void Env_SetFogCol (PackedCol color)
```

```c
void Env_SetCloudsCol (PackedCol color)
```

```c
void Env_SetSkyboxCol (PackedCol color)
```

```c
void Env_SetSunCol (PackedCol color)
```

```c
void Env_SetShadowCol (PackedCol color)
```

