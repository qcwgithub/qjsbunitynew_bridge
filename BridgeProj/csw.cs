
#pragma warning disable 626, 824
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Rect
    {
        public extern Rect(float left, float top, float width, float height);
        public extern Rect(Rect source);
         
        public Vector2 center { get { return default(Vector2); } set {} }
        public float height { get { return default(float); } set {} }
        public Vector2 max { get { return default(Vector2); } set {} }
        public Vector2 min { get { return default(Vector2); } set {} }
        public Vector2 position { get { return default(Vector2); } set {} }
        public Vector2 size { get { return default(Vector2); } set {} }
        public float width { get { return default(float); } set {} }
        public float x { get { return default(float); } set {} }
        public float xMax { get { return default(float); } set {} }
        public float xMin { get { return default(float); } set {} }
        public float y { get { return default(float); } set {} }
        public float yMax { get { return default(float); } set {} }
        public float yMin { get { return default(float); } set {} }
         
         
        public static extern bool operator ==(Rect lhs, Rect rhs);
        public static extern bool operator !=(Rect lhs, Rect rhs);
         
        public extern bool Contains(Vector2 point);
        public extern bool Contains(Vector3 point);
        public extern bool Contains(Vector3 point, bool allowInverse);
        public extern override bool Equals(object other);
        public extern override int GetHashCode();
        public extern bool Overlaps(Rect other);
        public extern bool Overlaps(Rect other, bool allowInverse);
        public extern void Set(float left, float top, float width, float height);
        public extern override string ToString();
        public extern string ToString(string format);
        public static extern Rect MinMaxRect(float left, float top, float right, float bottom);
        public static extern Vector2 NormalizedToPoint(Rect rectangle, Vector2 normalizedRectCoordinates);
        public static extern Vector2 PointToNormalized(Rect rectangle, Vector2 point);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;
         
        public extern Color(float r, float g, float b);
        public extern Color(float r, float g, float b, float a);
         
        public Color gamma { get { return default(Color); } }
        public float grayscale { get { return default(float); } }
        public Color linear { get { return default(Color); } }
        public static Color black { get { return default(Color); } }
        public static Color blue { get { return default(Color); } }
        public static Color clear { get { return default(Color); } }
        public static Color cyan { get { return default(Color); } }
        public static Color gray { get { return default(Color); } }
        public static Color green { get { return default(Color); } }
        public static Color grey { get { return default(Color); } }
        public static Color magenta { get { return default(Color); } }
        public static Color red { get { return default(Color); } }
        public static Color white { get { return default(Color); } }
        public static Color yellow { get { return default(Color); } }
         
        public float this[int index] { get { return default(float); } set {} }
         
        public static extern Color operator +(Color a, Color b);
        public static extern Color operator /(Color a, float b);
        public static extern bool operator ==(Color lhs, Color rhs);
        public static extern implicit operator Color(Vector4 v);
        public static extern implicit operator Vector4(Color c);
        public static extern bool operator !=(Color lhs, Color rhs);
        public static extern Color operator *(float b, Color a);
        public static extern Color operator *(Color a, float b);
        public static extern Color operator *(Color a, Color b);
        public static extern Color operator -(Color a, Color b);
         
        public extern override bool Equals(object other);
        public extern override int GetHashCode();
        public extern override string ToString();
        public extern string ToString(string format);
        public static extern Color Lerp(Color a, Color b, float t);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Physics
    {
        public static int kIgnoreRaycastLayer;
        public static int kDefaultRaycastLayers;
        public static int kAllLayers;
        public static int IgnoreRaycastLayer;
        public static int DefaultRaycastLayers;
        public static int AllLayers;
         
        public extern Physics();
         
        public static float bounceThreshold { get { return default(float); } set {} }
        public static Vector3 gravity { get { return default(Vector3); } set {} }
        public static float maxAngularVelocity { get { return default(float); } set {} }
        public static float minPenetrationForPenalty { get { return default(float); } set {} }
        public static float sleepAngularVelocity { get { return default(float); } set {} }
        public static float sleepVelocity { get { return default(float); } set {} }
        public static int solverIterationCount { get { return default(int); } set {} }
         
         
        public static extern bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction);
        public static extern bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance);
        public static extern bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance, int layerMask);
        public static extern bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo);
        public static extern bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float distance);
        public static extern bool CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, out RaycastHit hitInfo, float distance, int layerMask);
        public static extern RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction);
        public static extern RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance);
        public static extern RaycastHit[] CapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance, int layermask);
        public static extern bool CheckCapsule(Vector3 start, Vector3 end, float radius);
        public static extern bool CheckCapsule(Vector3 start, Vector3 end, float radius, int layermask);
        public static extern bool CheckSphere(Vector3 position, float radius);
        public static extern bool CheckSphere(Vector3 position, float radius, int layerMask);
        public static extern bool GetIgnoreLayerCollision(int layer1, int layer2);
        public static extern void IgnoreCollision(Collider collider1, Collider collider2);
        public static extern void IgnoreCollision(Collider collider1, Collider collider2, bool ignore);
        public static extern void IgnoreLayerCollision(int layer1, int layer2);
        public static extern void IgnoreLayerCollision(int layer1, int layer2, bool ignore);
        public static extern bool Linecast(Vector3 start, Vector3 end);
        public static extern bool Linecast(Vector3 start, Vector3 end, int layerMask);
        public static extern bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo);
        public static extern bool Linecast(Vector3 start, Vector3 end, out RaycastHit hitInfo, int layerMask);
        public static extern Collider[] OverlapSphere(Vector3 position, float radius);
        public static extern Collider[] OverlapSphere(Vector3 position, float radius, int layerMask);
        public static extern bool Raycast(Ray ray);
        public static extern bool Raycast(Ray ray, float distance);
        public static extern bool Raycast(Ray ray, float distance, int layerMask);
        public static extern bool Raycast(Ray ray, out RaycastHit hitInfo);
        public static extern bool Raycast(Ray ray, out RaycastHit hitInfo, float distance);
        public static extern bool Raycast(Ray ray, out RaycastHit hitInfo, float distance, int layerMask);
        public static extern bool Raycast(Vector3 origin, Vector3 direction);
        public static extern bool Raycast(Vector3 origin, Vector3 direction, float distance);
        public static extern bool Raycast(Vector3 origin, Vector3 direction, float distance, int layerMask);
        public static extern bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo);
        public static extern bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float distance);
        public static extern bool Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float distance, int layerMask);
        public static extern RaycastHit[] RaycastAll(Ray ray);
        public static extern RaycastHit[] RaycastAll(Ray ray, float distance);
        public static extern RaycastHit[] RaycastAll(Ray ray, float distance, int layerMask);
        public static extern RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction);
        public static extern RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float distance);
        public static extern RaycastHit[] RaycastAll(Vector3 origin, Vector3 direction, float distance, int layermask);
        public static extern bool SphereCast(Ray ray, float radius);
        public static extern bool SphereCast(Ray ray, float radius, float distance);
        public static extern bool SphereCast(Ray ray, float radius, float distance, int layerMask);
        public static extern bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo);
        public static extern bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float distance);
        public static extern bool SphereCast(Ray ray, float radius, out RaycastHit hitInfo, float distance, int layerMask);
        public static extern bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo);
        public static extern bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float distance);
        public static extern bool SphereCast(Vector3 origin, float radius, Vector3 direction, out RaycastHit hitInfo, float distance, int layerMask);
        public static extern RaycastHit[] SphereCastAll(Ray ray, float radius);
        public static extern RaycastHit[] SphereCastAll(Ray ray, float radius, float distance);
        public static extern RaycastHit[] SphereCastAll(Ray ray, float radius, float distance, int layerMask);
        public static extern RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction);
        public static extern RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float distance);
        public static extern RaycastHit[] SphereCastAll(Vector3 origin, float radius, Vector3 direction, float distance, int layerMask);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct RaycastHit
    {
         
        public Vector3 barycentricCoordinate { get { return default(Vector3); } set {} }
        public Collider collider { get { return default(Collider); } }
        public float distance { get { return default(float); } set {} }
        public Vector2 lightmapCoord { get { return default(Vector2); } }
        public Vector3 normal { get { return default(Vector3); } set {} }
        public Vector3 point { get { return default(Vector3); } set {} }
        public Rigidbody rigidbody { get { return default(Rigidbody); } }
        public Vector2 textureCoord { get { return default(Vector2); } }
        public Vector2 textureCoord2 { get { return default(Vector2); } }
        public Transform transform { get { return default(Transform); } }
        public int triangleIndex { get { return default(int); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Screen
    {
        public extern Screen();
         
        public static bool autorotateToLandscapeLeft { get { return default(bool); } set {} }
        public static bool autorotateToLandscapeRight { get { return default(bool); } set {} }
        public static bool autorotateToPortrait { get { return default(bool); } set {} }
        public static bool autorotateToPortraitUpsideDown { get { return default(bool); } set {} }
        public static Resolution currentResolution { get { return default(Resolution); } }
        public static float dpi { get { return default(float); } }
        public static bool fullScreen { get { return default(bool); } set {} }
        public static Resolution[] GetResolution { get { return default(Resolution[]); } }
        public static int height { get { return default(int); } }
        public static bool lockCursor { get { return default(bool); } set {} }
        public static ScreenOrientation orientation { get { return default(ScreenOrientation); } set {} }
        public static Resolution[] resolutions { get { return default(Resolution[]); } }
        public static bool showCursor { get { return default(bool); } set {} }
        public static int sleepTimeout { get { return default(int); } set {} }
        public static int width { get { return default(int); } }
         
         
        public static extern void SetResolution(int width, int height, bool fullscreen);
        public static extern void SetResolution(int width, int height, bool fullscreen, int preferredRefreshRate);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Quaternion
    {
        public static float kEpsilon;
        public float x;
        public float y;
        public float z;
        public float w;
         
        public extern Quaternion(float x, float y, float z, float w);
         
        public Vector3 eulerAngles { get { return default(Vector3); } set {} }
        public static Quaternion identity { get { return default(Quaternion); } }
         
        public float this[int index] { get { return default(float); } set {} }
         
        public static extern bool operator ==(Quaternion lhs, Quaternion rhs);
        public static extern bool operator !=(Quaternion lhs, Quaternion rhs);
        public static extern Quaternion operator *(Quaternion lhs, Quaternion rhs);
        public static extern Vector3 operator *(Quaternion rotation, Vector3 point);
         
        public extern override bool Equals(object other);
        public extern override int GetHashCode();
        public extern void Set(float new_x, float new_y, float new_z, float new_w);
        public extern void SetFromToRotation(Vector3 fromDirection, Vector3 toDirection);
        public extern void SetLookRotation(Vector3 view);
        public extern void SetLookRotation(Vector3 view, Vector3 up);
        public extern void ToAngleAxis(out float angle, out Vector3 axis);
        public extern override string ToString();
        public extern string ToString(string format);
        public static extern float Angle(Quaternion a, Quaternion b);
        public static extern Quaternion AngleAxis(float angle, Vector3 axis);
        public static extern float Dot(Quaternion a, Quaternion b);
        public static extern Quaternion Euler(float x, float y, float z);
        public static extern Quaternion Euler(Vector3 euler);
        public static extern Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection);
        public static extern Quaternion Inverse(Quaternion rotation);
        public static extern Quaternion Lerp(Quaternion from, Quaternion to, float t);
        public static extern Quaternion LookRotation(Vector3 forward);
        public static extern Quaternion LookRotation(Vector3 forward, Vector3 upwards);
        public static extern Quaternion RotateTowards(Quaternion from, Quaternion to, float maxDegreesDelta);
        public static extern Quaternion Slerp(Quaternion from, Quaternion to, float t);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Physics2D
    {
        public static int IgnoreRaycastLayer;
        public static int DefaultRaycastLayers;
        public static int AllLayers;
         
        public extern Physics2D();
         
        public static float angularSleepTolerance { get { return default(float); } set {} }
        public static float baumgarteScale { get { return default(float); } set {} }
        public static float baumgarteTOIScale { get { return default(float); } set {} }
        public static bool changeStopsCallbacks { get { return default(bool); } set {} }
        public static Vector2 gravity { get { return default(Vector2); } set {} }
        public static float linearSleepTolerance { get { return default(float); } set {} }
        public static float maxAngularCorrection { get { return default(float); } set {} }
        public static float maxLinearCorrection { get { return default(float); } set {} }
        public static float maxRotationSpeed { get { return default(float); } set {} }
        public static float maxTranslationSpeed { get { return default(float); } set {} }
        public static float minPenetrationForPenalty { get { return default(float); } set {} }
        public static int positionIterations { get { return default(int); } set {} }
        public static bool raycastsHitTriggers { get { return default(bool); } set {} }
        public static bool raycastsStartInColliders { get { return default(bool); } set {} }
        public static float timeToSleep { get { return default(float); } set {} }
        public static int velocityIterations { get { return default(int); } set {} }
        public static float velocityThreshold { get { return default(float); } set {} }
         
         
        public static extern RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction);
        public static extern RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance);
        public static extern RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask);
        public static extern RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth);
        public static extern RaycastHit2D BoxCast(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth);
        public static extern RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction);
        public static extern RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance);
        public static extern RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask);
        public static extern RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth);
        public static extern RaycastHit2D[] BoxCastAll(Vector2 origin, Vector2 size, float angle, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth);
        public static extern int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results);
        public static extern int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance);
        public static extern int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask);
        public static extern int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth);
        public static extern int BoxCastNonAlloc(Vector2 origin, Vector2 size, float angle, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth);
        public static extern RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction);
        public static extern RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance);
        public static extern RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask);
        public static extern RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth);
        public static extern RaycastHit2D CircleCast(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth);
        public static extern RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction);
        public static extern RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance);
        public static extern RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask);
        public static extern RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth);
        public static extern RaycastHit2D[] CircleCastAll(Vector2 origin, float radius, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth);
        public static extern int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results);
        public static extern int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance);
        public static extern int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask);
        public static extern int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth);
        public static extern int CircleCastNonAlloc(Vector2 origin, float radius, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth);
        public static extern bool GetIgnoreCollision(Collider2D collider1, Collider2D collider2);
        public static extern bool GetIgnoreLayerCollision(int layer1, int layer2);
        public static extern RaycastHit2D GetRayIntersection(Ray ray);
        public static extern RaycastHit2D GetRayIntersection(Ray ray, float distance);
        public static extern RaycastHit2D GetRayIntersection(Ray ray, float distance, int layerMask);
        public static extern RaycastHit2D[] GetRayIntersectionAll(Ray ray);
        public static extern RaycastHit2D[] GetRayIntersectionAll(Ray ray, float distance);
        public static extern RaycastHit2D[] GetRayIntersectionAll(Ray ray, float distance, int layerMask);
        public static extern int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results);
        public static extern int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results, float distance);
        public static extern int GetRayIntersectionNonAlloc(Ray ray, RaycastHit2D[] results, float distance, int layerMask);
        public static extern void IgnoreCollision(Collider2D collider1, Collider2D collider2);
        public static extern void IgnoreCollision(Collider2D collider1, Collider2D collider2, bool ignore);
        public static extern void IgnoreLayerCollision(int layer1, int layer2);
        public static extern void IgnoreLayerCollision(int layer1, int layer2, bool ignore);
        public static extern RaycastHit2D Linecast(Vector2 start, Vector2 end);
        public static extern RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask);
        public static extern RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask, float minDepth);
        public static extern RaycastHit2D Linecast(Vector2 start, Vector2 end, int layerMask, float minDepth, float maxDepth);
        public static extern RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end);
        public static extern RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask);
        public static extern RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask, float minDepth);
        public static extern RaycastHit2D[] LinecastAll(Vector2 start, Vector2 end, int layerMask, float minDepth, float maxDepth);
        public static extern int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results);
        public static extern int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask);
        public static extern int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask, float minDepth);
        public static extern int LinecastNonAlloc(Vector2 start, Vector2 end, RaycastHit2D[] results, int layerMask, float minDepth, float maxDepth);
        public static extern Collider2D OverlapArea(Vector2 pointA, Vector2 pointB);
        public static extern Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask);
        public static extern Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth);
        public static extern Collider2D OverlapArea(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth);
        public static extern Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB);
        public static extern Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask);
        public static extern Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth);
        public static extern Collider2D[] OverlapAreaAll(Vector2 pointA, Vector2 pointB, int layerMask, float minDepth, float maxDepth);
        public static extern int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results);
        public static extern int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask);
        public static extern int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth);
        public static extern int OverlapAreaNonAlloc(Vector2 pointA, Vector2 pointB, Collider2D[] results, int layerMask, float minDepth, float maxDepth);
        public static extern Collider2D OverlapCircle(Vector2 point, float radius);
        public static extern Collider2D OverlapCircle(Vector2 point, float radius, int layerMask);
        public static extern Collider2D OverlapCircle(Vector2 point, float radius, int layerMask, float minDepth);
        public static extern Collider2D OverlapCircle(Vector2 point, float radius, int layerMask, float minDepth, float maxDepth);
        public static extern Collider2D[] OverlapCircleAll(Vector2 point, float radius);
        public static extern Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask);
        public static extern Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask, float minDepth);
        public static extern Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask, float minDepth, float maxDepth);
        public static extern int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results);
        public static extern int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask);
        public static extern int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask, float minDepth);
        public static extern int OverlapCircleNonAlloc(Vector2 point, float radius, Collider2D[] results, int layerMask, float minDepth, float maxDepth);
        public static extern Collider2D OverlapPoint(Vector2 point);
        public static extern Collider2D OverlapPoint(Vector2 point, int layerMask);
        public static extern Collider2D OverlapPoint(Vector2 point, int layerMask, float minDepth);
        public static extern Collider2D OverlapPoint(Vector2 point, int layerMask, float minDepth, float maxDepth);
        public static extern Collider2D[] OverlapPointAll(Vector2 point);
        public static extern Collider2D[] OverlapPointAll(Vector2 point, int layerMask);
        public static extern Collider2D[] OverlapPointAll(Vector2 point, int layerMask, float minDepth);
        public static extern Collider2D[] OverlapPointAll(Vector2 point, int layerMask, float minDepth, float maxDepth);
        public static extern int OverlapPointNonAlloc(Vector2 point, Collider2D[] results);
        public static extern int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask);
        public static extern int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth);
        public static extern int OverlapPointNonAlloc(Vector2 point, Collider2D[] results, int layerMask, float minDepth, float maxDepth);
        public static extern RaycastHit2D Raycast(Vector2 origin, Vector2 direction);
        public static extern RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance);
        public static extern RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask);
        public static extern RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth);
        public static extern RaycastHit2D Raycast(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth);
        public static extern RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction);
        public static extern RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance);
        public static extern RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask);
        public static extern RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth);
        public static extern RaycastHit2D[] RaycastAll(Vector2 origin, Vector2 direction, float distance, int layerMask, float minDepth, float maxDepth);
        public static extern int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results);
        public static extern int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance);
        public static extern int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask);
        public static extern int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth);
        public static extern int RaycastNonAlloc(Vector2 origin, Vector2 direction, RaycastHit2D[] results, float distance, int layerMask, float minDepth, float maxDepth);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct LayerMask
    {
         
        public int value { get { return default(int); } set {} }
         
         
        public static extern implicit operator int(LayerMask mask);
        public static extern implicit operator LayerMask(int intVal);
         
        public static extern int GetMask(params string[] layerNames);
        public static extern string LayerToName(int layer);
        public static extern int NameToLayer(string layerName);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Collision2D
    {
        public extern Collision2D();
         
        public Collider2D collider { get { return default(Collider2D); } }
        public ContactPoint2D[] contacts { get { return default(ContactPoint2D[]); } }
        public GameObject gameObject { get { return default(GameObject); } }
        public Vector2 relativeVelocity { get { return default(Vector2); } }
        public Rigidbody2D rigidbody { get { return default(Rigidbody2D); } }
        public Transform transform { get { return default(Transform); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Mathf
    {
        public static float PI;
        public static float Infinity;
        public static float NegativeInfinity;
        public static float Deg2Rad;
        public static float Rad2Deg;
        public static float Epsilon;
         
         
        public static extern int Abs(int value);
        public static extern float Abs(float f);
        public static extern float Acos(float f);
        public static extern bool Approximately(float a, float b);
        public static extern float Asin(float f);
        public static extern float Atan(float f);
        public static extern float Atan2(float y, float x);
        public static extern float Ceil(float f);
        public static extern int CeilToInt(float f);
        public static extern int Clamp(int value, int min, int max);
        public static extern float Clamp(float value, float min, float max);
        public static extern float Clamp01(float value);
        public static extern int ClosestPowerOfTwo(int value);
        public static extern float Cos(float f);
        public static extern float DeltaAngle(float current, float target);
        public static extern float Exp(float power);
        public static extern float Floor(float f);
        public static extern int FloorToInt(float f);
        public static extern float Gamma(float value, float absmax, float gamma);
        public static extern float GammaToLinearSpace(float value);
        public static extern float InverseLerp(float from, float to, float value);
        public static extern bool IsPowerOfTwo(int value);
        public static extern float Lerp(float from, float to, float t);
        public static extern float LerpAngle(float a, float b, float t);
        public static extern float LinearToGammaSpace(float value);
        public static extern float Log(float f);
        public static extern float Log(float f, float p);
        public static extern float Log10(float f);
        public static extern int Max(int a, int b);
        public static extern int Max(params int[] values);
        public static extern float Max(float a, float b);
        public static extern float Max(params float[] values);
        public static extern int Min(int a, int b);
        public static extern int Min(params int[] values);
        public static extern float Min(float a, float b);
        public static extern float Min(params float[] values);
        public static extern float MoveTowards(float current, float target, float maxDelta);
        public static extern float MoveTowardsAngle(float current, float target, float maxDelta);
        public static extern int NextPowerOfTwo(int value);
        public static extern float PerlinNoise(float x, float y);
        public static extern float PingPong(float t, float length);
        public static extern float Pow(float f, float p);
        public static extern float Repeat(float t, float length);
        public static extern float Round(float f);
        public static extern int RoundToInt(float f);
        public static extern float Sign(float f);
        public static extern float Sin(float f);
        public static extern float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime);
        public static extern float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed);
        public static extern float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime);
        public static extern float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime);
        public static extern float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed);
        public static extern float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed, float deltaTime);
        public static extern float SmoothStep(float from, float to, float t);
        public static extern float Sqrt(float f);
        public static extern float Tan(float f);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct RaycastHit2D
    {
         
        public Vector2 centroid { get { return default(Vector2); } set {} }
        public Collider2D collider { get { return default(Collider2D); } }
        public float distance { get { return default(float); } set {} }
        public float fraction { get { return default(float); } set {} }
        public Vector2 normal { get { return default(Vector2); } set {} }
        public Vector2 point { get { return default(Vector2); } set {} }
        public Rigidbody2D rigidbody { get { return default(Rigidbody2D); } }
        public Transform transform { get { return default(Transform); } }
         
         
        public static extern implicit operator bool(RaycastHit2D hit);
         
        public extern int CompareTo(RaycastHit2D other);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct AnimatorStateInfo
    {
         
        public float length { get { return default(float); } }
        public bool loop { get { return default(bool); } }
        public int nameHash { get { return default(int); } }
        public float normalizedTime { get { return default(float); } }
        public int tagHash { get { return default(int); } }
         
         
        public extern bool IsName(string name);
        public extern bool IsTag(string tag);
    }
}
 
namespace System.Collections
{
    [Bridge.FileName("csw")]
    public interface IDictionary : IEnumerable, ICollection
    {
        bool IsFixedSize { get; }
        bool IsReadOnly { get; }
        ICollection Keys { get; }
        ICollection Values { get; }
         
        object this[object key] { get; set; }
         
        void Add(object key, object value);
        void Clear();
        bool Contains(object key);
        IDictionaryEnumerator GetEnumerator();
        void Remove(object key);
    }
}
 
namespace System.Runtime.Serialization
{
    [Bridge.FileName("csw")]
    public interface ISerializable
    {
        void GetObjectData(SerializationInfo info, StreamingContext context);
    }
}
 
namespace System.Runtime.Serialization
{
    [Bridge.FileName("csw")]
    public interface IDeserializationCallback
    {
        void OnDeserialization(object sender);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public interface ISerializationCallbackReceiver
    {
        void OnAfterDeserialize();
        void OnBeforeSerialize();
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface IEventSystemHandler
    {
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public interface ICanvasElement
    {
        UnityEngine.Transform transform { get; }
         
         
        bool IsDestroyed();
        void Rebuild(CanvasUpdate executing);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class YieldInstruction
    {
        public extern YieldInstruction();
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class NavMeshPath
    {
        public extern NavMeshPath();
         
        public Vector3[] corners { get { return default(Vector3[]); } }
        public NavMeshPathStatus status { get { return default(NavMeshPathStatus); } }
         
         
        public extern void ClearCorners();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public interface ILayoutElement
    {
        float flexibleHeight { get; }
        float flexibleWidth { get; }
        int layoutPriority { get; }
        float minHeight { get; }
        float minWidth { get; }
        float preferredHeight { get; }
        float preferredWidth { get; }
         
         
        void CalculateLayoutInputHorizontal();
        void CalculateLayoutInputVertical();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public interface IMaskable
    {
        void ParentMaskStateChanged();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public interface ILayoutController
    {
        void SetLayoutHorizontal();
        void SetLayoutVertical();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Vector2
    {
        public static float kEpsilon;
        public float x;
        public float y;
         
        public extern Vector2(float x, float y);
         
        public float magnitude { get { return default(float); } }
        public Vector2 normalized { get { return default(Vector2); } }
        public float sqrMagnitude { get { return default(float); } }
        public static Vector2 one { get { return default(Vector2); } }
        public static Vector2 right { get { return default(Vector2); } }
        public static Vector2 up { get { return default(Vector2); } }
        public static Vector2 zero { get { return default(Vector2); } }
         
        public float this[int index] { get { return default(float); } set {} }
         
        public static extern Vector2 operator +(Vector2 a, Vector2 b);
        public static extern Vector2 operator /(Vector2 a, float d);
        public static extern bool operator ==(Vector2 lhs, Vector2 rhs);
        public static extern implicit operator Vector2(Vector3 v);
        public static extern implicit operator Vector3(Vector2 v);
        public static extern bool operator !=(Vector2 lhs, Vector2 rhs);
        public static extern Vector2 operator *(float d, Vector2 a);
        public static extern Vector2 operator *(Vector2 a, float d);
        public static extern Vector2 operator -(Vector2 a, Vector2 b);
        public static extern Vector2 operator -(Vector2 a);
         
        public extern override bool Equals(object other);
        public extern override int GetHashCode();
        public extern void Normalize();
        public extern void Scale(Vector2 scale);
        public extern void Set(float new_x, float new_y);
        public extern float SqrMagnitude();
        public extern override string ToString();
        public extern string ToString(string format);
        public static extern float Angle(Vector2 from, Vector2 to);
        public static extern Vector2 ClampMagnitude(Vector2 vector, float maxLength);
        public static extern float Distance(Vector2 a, Vector2 b);
        public static extern float Dot(Vector2 lhs, Vector2 rhs);
        public static extern Vector2 Lerp(Vector2 from, Vector2 to, float t);
        public static extern Vector2 Max(Vector2 lhs, Vector2 rhs);
        public static extern Vector2 Min(Vector2 lhs, Vector2 rhs);
        public static extern Vector2 MoveTowards(Vector2 current, Vector2 target, float maxDistanceDelta);
        public static extern Vector2 Scale(Vector2 a, Vector2 b);
        public static extern Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime);
        public static extern Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed);
        public static extern Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime, float maxSpeed, float deltaTime);
        public static extern float SqrMagnitude(Vector2 a);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Input
    {
        public extern Input();
         
        public static Vector3 acceleration { get { return default(Vector3); } }
        public static int accelerationEventCount { get { return default(int); } }
        public static AccelerationEvent[] accelerationEvents { get { return default(AccelerationEvent[]); } }
        public static bool anyKey { get { return default(bool); } }
        public static bool anyKeyDown { get { return default(bool); } }
        public static Compass compass { get { return default(Compass); } }
        public static bool compensateSensors { get { return default(bool); } set {} }
        public static Vector2 compositionCursorPos { get { return default(Vector2); } set {} }
        public static string compositionString { get { return default(string); } }
        public static DeviceOrientation deviceOrientation { get { return default(DeviceOrientation); } }
        public static Gyroscope gyro { get { return default(Gyroscope); } }
        public static IMECompositionMode imeCompositionMode { get { return default(IMECompositionMode); } set {} }
        public static bool imeIsSelected { get { return default(bool); } }
        public static string inputString { get { return default(string); } }
        public static LocationService location { get { return default(LocationService); } }
        public static Vector3 mousePosition { get { return default(Vector3); } }
        public static bool mousePresent { get { return default(bool); } }
        public static Vector3 mouseScrollDelta { get { return default(Vector3); } }
        public static bool multiTouchEnabled { get { return default(bool); } set {} }
        public static bool simulateMouseWithTouches { get { return default(bool); } set {} }
        public static int touchCount { get { return default(int); } }
        public static Touch[] touches { get { return default(Touch[]); } }
        public static bool touchSupported { get { return default(bool); } }
         
         
        public static extern AccelerationEvent GetAccelerationEvent(int index);
        public static extern float GetAxis(string axisName);
        public static extern float GetAxisRaw(string axisName);
        public static extern bool GetButton(string buttonName);
        public static extern bool GetButtonDown(string buttonName);
        public static extern bool GetButtonUp(string buttonName);
        public static extern string[] GetJoystickNames();
        public static extern bool GetKey(string name);
        public static extern bool GetKey(KeyCode key);
        public static extern bool GetKeyDown(string name);
        public static extern bool GetKeyDown(KeyCode key);
        public static extern bool GetKeyUp(string name);
        public static extern bool GetKeyUp(KeyCode key);
        public static extern bool GetMouseButton(int button);
        public static extern bool GetMouseButtonDown(int button);
        public static extern bool GetMouseButtonUp(int button);
        public static extern Touch GetTouch(int index);
        public static extern void ResetInputAxes();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Vector3
    {
        public static float kEpsilon;
        public float x;
        public float y;
        public float z;
         
        public extern Vector3(float x, float y);
        public extern Vector3(float x, float y, float z);
         
        public float magnitude { get { return default(float); } }
        public Vector3 normalized { get { return default(Vector3); } }
        public float sqrMagnitude { get { return default(float); } }
        public static Vector3 back { get { return default(Vector3); } }
        public static Vector3 down { get { return default(Vector3); } }
        public static Vector3 forward { get { return default(Vector3); } }
        public static Vector3 left { get { return default(Vector3); } }
        public static Vector3 one { get { return default(Vector3); } }
        public static Vector3 right { get { return default(Vector3); } }
        public static Vector3 up { get { return default(Vector3); } }
        public static Vector3 zero { get { return default(Vector3); } }
         
        public float this[int index] { get { return default(float); } set {} }
         
        public static extern Vector3 operator +(Vector3 a, Vector3 b);
        public static extern Vector3 operator /(Vector3 a, float d);
        public static extern bool operator ==(Vector3 lhs, Vector3 rhs);
        public static extern bool operator !=(Vector3 lhs, Vector3 rhs);
        public static extern Vector3 operator *(float d, Vector3 a);
        public static extern Vector3 operator *(Vector3 a, float d);
        public static extern Vector3 operator -(Vector3 a, Vector3 b);
        public static extern Vector3 operator -(Vector3 a);
         
        public extern override bool Equals(object other);
        public extern override int GetHashCode();
        public extern void Normalize();
        public extern void Scale(Vector3 scale);
        public extern void Set(float new_x, float new_y, float new_z);
        public extern override string ToString();
        public extern string ToString(string format);
        public static extern float Angle(Vector3 from, Vector3 to);
        public static extern Vector3 ClampMagnitude(Vector3 vector, float maxLength);
        public static extern Vector3 Cross(Vector3 lhs, Vector3 rhs);
        public static extern float Distance(Vector3 a, Vector3 b);
        public static extern float Dot(Vector3 lhs, Vector3 rhs);
        public static extern Vector3 Lerp(Vector3 from, Vector3 to, float t);
        public static extern float Magnitude(Vector3 a);
        public static extern Vector3 Max(Vector3 lhs, Vector3 rhs);
        public static extern Vector3 Min(Vector3 lhs, Vector3 rhs);
        public static extern Vector3 MoveTowards(Vector3 current, Vector3 target, float maxDistanceDelta);
        public static extern Vector3 Normalize(Vector3 value);
        public static extern void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent);
        public static extern void OrthoNormalize(ref Vector3 normal, ref Vector3 tangent, ref Vector3 binormal);
        public static extern Vector3 Project(Vector3 vector, Vector3 onNormal);
        public static extern Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal);
        public static extern Vector3 Reflect(Vector3 inDirection, Vector3 inNormal);
        public static extern Vector3 RotateTowards(Vector3 current, Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta);
        public static extern Vector3 Scale(Vector3 a, Vector3 b);
        public static extern Vector3 Slerp(Vector3 from, Vector3 to, float t);
        public static extern Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime);
        public static extern Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed);
        public static extern Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed, float deltaTime);
        public static extern float SqrMagnitude(Vector3 a);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class WWW : System.IDisposable
    {
        public extern WWW(string url);
        public extern WWW(string url, byte[] postData);
        public extern WWW(string url, byte[] postData, System.Collections.Generic.Dictionary<System.String,System.String> headers);
        public extern WWW(string url, WWWForm form);
         
        public AssetBundle assetBundle { get { return default(AssetBundle); } }
        public AudioClip audioClip { get { return default(AudioClip); } }
        public byte[] bytes { get { return default(byte[]); } }
        public int bytesDownloaded { get { return default(int); } }
        public string error { get { return default(string); } }
        public bool isDone { get { return default(bool); } }
        public float progress { get { return default(float); } }
        public System.Collections.Generic.Dictionary<System.String,System.String> responseHeaders { get { return default(System.Collections.Generic.Dictionary<System.String,System.String>); } }
        public int size { get { return default(int); } }
        public string text { get { return default(string); } }
        public Texture2D texture { get { return default(Texture2D); } }
        public Texture2D textureNonReadable { get { return default(Texture2D); } }
        public ThreadPriority threadPriority { get { return default(ThreadPriority); } set {} }
        public float uploadProgress { get { return default(float); } }
        public string url { get { return default(string); } }
         
         
        public extern virtual void Dispose();
        public extern AudioClip GetAudioClip(bool threeD);
        public extern AudioClip GetAudioClip(bool threeD, bool stream);
        public extern AudioClip GetAudioClip(bool threeD, bool stream, AudioType audioType);
        public extern AudioClip GetAudioClipCompressed();
        public extern AudioClip GetAudioClipCompressed(bool threeD);
        public extern AudioClip GetAudioClipCompressed(bool threeD, AudioType audioType);
        public extern void InitWWW(string url, byte[] postData, string[] iHeaders);
        public extern void LoadImageIntoTexture(Texture2D tex);
        public extern void LoadUnityWeb();
        public static extern string EscapeURL(string s);
        public static extern string EscapeURL(string s, System.Text.Encoding e);
        public static extern WWW LoadFromCacheOrDownload(string url, int version);
        public static extern WWW LoadFromCacheOrDownload(string url, int version, uint crc);
        public static extern string UnEscapeURL(string s);
        public static extern string UnEscapeURL(string s, System.Text.Encoding e);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Object
    {
        public extern Object();
         
        public HideFlags hideFlags { get { return default(HideFlags); } set {} }
        public string name { get { return default(string); } set {} }
         
         
        public static extern bool operator ==(Object x, Object y);
        public static extern implicit operator bool(Object exists);
        public static extern bool operator !=(Object x, Object y);
         
        public extern override bool Equals(object o);
        public extern override int GetHashCode();
        public extern int GetInstanceID();
        public extern override string ToString();
        public static extern void Destroy(Object obj);
        public static extern void Destroy(Object obj, float t);
        public static extern void DestroyImmediate(Object obj);
        public static extern void DestroyImmediate(Object obj, bool allowDestroyingAssets);
        public static extern void DestroyObject(Object obj);
        public static extern void DestroyObject(Object obj, float t);
        public static extern void DontDestroyOnLoad(Object target);
        public static extern T FindObjectOfType<T>();
        public static extern Object FindObjectOfType(System.Type type);
        public static extern T[] FindObjectsOfType<T>();
        public static extern Object[] FindObjectsOfType(System.Type type);
        public static extern Object Instantiate(Object original);
        public static extern Object Instantiate(Object original, Vector3 position, Quaternion rotation);
    }
}
 
namespace jsb.Test.Framwork
{
    [Bridge.FileName("csw")]
    public class TestMisc
    {
        public extern TestMisc();
         
        public extern void TestParams(params string[] strs);
        public static extern void GetL(System.Action<System.Int64> jsSetL);
        public static extern void GetUL(System.Action<System.UInt64> jsSetUL);
        public static extern void SetL(long l);
        public static extern void SetUL(ulong ul);
    }
}
 
namespace jsb.Test.Framwork
{
    [Bridge.FileName("csw")]
    public class TestPerformance
    {
            [Bridge.FileName("csw")]
            public class RefObject
            {
                public string String;
                public int x;
                public int y;
                 
                public extern RefObject();
                 
            }
        public static TestPerformance.RefObject StaticObject;
         
        public extern TestPerformance();
         
        public static extern void test123(params object[] ts);
        public static extern void testString(params string[] ts);
    }
}
 
namespace jsb.Test.Framwork
{
    [Bridge.FileName("csw")]
    public class TestRF
    {
        public extern TestRF();
         
        public static extern void Get_Out(out int x);
        public static extern void Increase_ByRef(bool bInc, ref int x);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Debug
    {
        public extern Debug();
         
        public static bool developerConsoleVisible { get { return default(bool); } set {} }
        public static bool isDebugBuild { get { return default(bool); } }
         
         
        public static extern void Break();
        public static extern void ClearDeveloperConsole();
        public static extern void DebugBreak();
        public static extern void DrawLine(Vector3 start, Vector3 end);
        public static extern void DrawLine(Vector3 start, Vector3 end, Color color);
        public static extern void DrawLine(Vector3 start, Vector3 end, Color color, float duration);
        public static extern void DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest);
        public static extern void DrawRay(Vector3 start, Vector3 dir);
        public static extern void DrawRay(Vector3 start, Vector3 dir, Color color);
        public static extern void DrawRay(Vector3 start, Vector3 dir, Color color, float duration);
        public static extern void DrawRay(Vector3 start, Vector3 dir, Color color, float duration, bool depthTest);
        public static extern void Log(object message);
        public static extern void Log(object message, Object context);
        public static extern void LogError(object message);
        public static extern void LogError(object message, Object context);
        public static extern void LogException(System.Exception exception);
        public static extern void LogException(System.Exception exception, Object context);
        public static extern void LogWarning(object message);
        public static extern void LogWarning(object message, Object context);
    }
}
 
namespace jsb.Test.Framwork
{
    [Bridge.FileName("csw")]
    public class TestGeneric<T,J,K>
    {
        public extern TestGeneric(T o);
         
        public extern void Hello<X, Y>();
        public extern void PrintName();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Application
    {
            public delegate void LogCallback(string condition, string stackTrace, LogType type);
        public extern Application();
         
        public static string absoluteURL { get { return default(string); } }
        public static ThreadPriority backgroundLoadingPriority { get { return default(ThreadPriority); } set {} }
        public static string dataPath { get { return default(string); } }
        public static bool genuine { get { return default(bool); } }
        public static bool genuineCheckAvailable { get { return default(bool); } }
        public static NetworkReachability internetReachability { get { return default(NetworkReachability); } }
        public static bool isConsolePlatform { get { return default(bool); } }
        public static bool isEditor { get { return default(bool); } }
        public static bool isLoadingLevel { get { return default(bool); } }
        public static bool isMobilePlatform { get { return default(bool); } }
        public static bool isPlaying { get { return default(bool); } }
        public static bool isWebPlayer { get { return default(bool); } }
        public static int levelCount { get { return default(int); } }
        public static int loadedLevel { get { return default(int); } }
        public static string loadedLevelName { get { return default(string); } }
        public static string persistentDataPath { get { return default(string); } }
        public static RuntimePlatform platform { get { return default(RuntimePlatform); } }
        public static bool runInBackground { get { return default(bool); } set {} }
        public static string srcValue { get { return default(string); } }
        public static int streamedBytes { get { return default(int); } }
        public static string streamingAssetsPath { get { return default(string); } }
        public static SystemLanguage systemLanguage { get { return default(SystemLanguage); } }
        public static int targetFrameRate { get { return default(int); } set {} }
        public static string temporaryCachePath { get { return default(string); } }
        public static string unityVersion { get { return default(string); } }
        public static bool webSecurityEnabled { get { return default(bool); } }
        public static string webSecurityHostUrl { get { return default(string); } }
         
         
        public static extern void CancelQuit();
        public static extern bool CanStreamedLevelBeLoaded(int levelIndex);
        public static extern bool CanStreamedLevelBeLoaded(string levelName);
        public static extern void CaptureScreenshot(string filename);
        public static extern void CaptureScreenshot(string filename, int superSize);
        public static extern void ExternalCall(string functionName, params object[] args);
        public static extern float GetStreamProgressForLevel(int levelIndex);
        public static extern float GetStreamProgressForLevel(string levelName);
        public static extern bool HasProLicense();
        public static extern bool HasUserAuthorization(UserAuthorization mode);
        public static extern void LoadLevel(int index);
        public static extern void LoadLevel(string name);
        public static extern void LoadLevelAdditive(int index);
        public static extern void LoadLevelAdditive(string name);
        public static extern AsyncOperation LoadLevelAdditiveAsync(int index);
        public static extern AsyncOperation LoadLevelAdditiveAsync(string levelName);
        public static extern AsyncOperation LoadLevelAsync(int index);
        public static extern AsyncOperation LoadLevelAsync(string levelName);
        public static extern void OpenURL(string url);
        public static extern void Quit();
        public static extern void RegisterLogCallback(Application.LogCallback handler);
        public static extern void RegisterLogCallbackThreaded(Application.LogCallback handler);
        public static extern AsyncOperation RequestUserAuthorization(UserAuthorization mode);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Time
    {
        public extern Time();
         
        public static int captureFramerate { get { return default(int); } set {} }
        public static float deltaTime { get { return default(float); } }
        public static float fixedDeltaTime { get { return default(float); } set {} }
        public static float fixedTime { get { return default(float); } }
        public static int frameCount { get { return default(int); } }
        public static float maximumDeltaTime { get { return default(float); } set {} }
        public static float realtimeSinceStartup { get { return default(float); } }
        public static int renderedFrameCount { get { return default(int); } }
        public static float smoothDeltaTime { get { return default(float); } }
        public static float time { get { return default(float); } }
        public static float timeScale { get { return default(float); } set {} }
        public static float timeSinceLevelLoad { get { return default(float); } }
        public static float unscaledDeltaTime { get { return default(float); } }
        public static float unscaledTime { get { return default(float); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Resources
    {
        public extern Resources();
         
        public static extern T[] FindObjectsOfTypeAll<T>();
        public static extern Object[] FindObjectsOfTypeAll(System.Type type);
        public static extern T GetBuiltinResource<T>(string path);
        public static extern Object GetBuiltinResource(System.Type type, string path);
        public static extern T Load<T>(string path);
        public static extern Object Load(string path);
        public static extern Object Load(string path, System.Type systemTypeInstance);
        public static extern T[] LoadAll<T>(string path);
        public static extern Object[] LoadAll(string path);
        public static extern Object[] LoadAll(string path, System.Type systemTypeInstance);
        public static extern T LoadAssetAtPath<T>(string assetPath);
        public static extern Object LoadAssetAtPath(string assetPath, System.Type type);
        public static extern ResourceRequest LoadAsync(string path);
        public static extern ResourceRequest LoadAsync(string path, System.Type type);
        public static extern ResourceRequest LoadAsync<T>(string path);
        public static extern void UnloadAsset(Object assetToUnload);
        public static extern AsyncOperation UnloadUnusedAssets();
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface IPointerClickHandler : IEventSystemHandler
    {
        void OnPointerClick(PointerEventData eventData);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class TextAsset : Object
    {
        public extern TextAsset();
         
        public byte[] bytes { get { return default(byte[]); } }
        public string text { get { return default(string); } }
         
         
        public extern override string ToString();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Material : Object
    {
        public extern Material(string contents);
        public extern Material(Material source);
        public extern Material(Shader shader);
         
        public Color color { get { return default(Color); } set {} }
        public Texture mainTexture { get { return default(Texture); } set {} }
        public Vector2 mainTextureOffset { get { return default(Vector2); } set {} }
        public Vector2 mainTextureScale { get { return default(Vector2); } set {} }
        public int passCount { get { return default(int); } }
        public int renderQueue { get { return default(int); } set {} }
        public Shader shader { get { return default(Shader); } set {} }
        public string[] shaderKeywords { get { return default(string[]); } set {} }
         
         
        public extern void CopyPropertiesFromMaterial(Material mat);
        public extern void DisableKeyword(string keyword);
        public extern void EnableKeyword(string keyword);
        public extern Color GetColor(int nameID);
        public extern Color GetColor(string propertyName);
        public extern float GetFloat(int nameID);
        public extern float GetFloat(string propertyName);
        public extern int GetInt(int nameID);
        public extern int GetInt(string propertyName);
        public extern Matrix4x4 GetMatrix(int nameID);
        public extern Matrix4x4 GetMatrix(string propertyName);
        public extern string GetTag(string tag, bool searchFallbacks);
        public extern string GetTag(string tag, bool searchFallbacks, string defaultValue);
        public extern Texture GetTexture(int nameID);
        public extern Texture GetTexture(string propertyName);
        public extern Vector2 GetTextureOffset(string propertyName);
        public extern Vector2 GetTextureScale(string propertyName);
        public extern Vector4 GetVector(int nameID);
        public extern Vector4 GetVector(string propertyName);
        public extern bool HasProperty(int nameID);
        public extern bool HasProperty(string propertyName);
        public extern void Lerp(Material start, Material end, float t);
        public extern void SetBuffer(string propertyName, ComputeBuffer buffer);
        public extern void SetColor(int nameID, Color color);
        public extern void SetColor(string propertyName, Color color);
        public extern void SetFloat(int nameID, float value);
        public extern void SetFloat(string propertyName, float value);
        public extern void SetInt(int nameID, int value);
        public extern void SetInt(string propertyName, int value);
        public extern void SetMatrix(int nameID, Matrix4x4 matrix);
        public extern void SetMatrix(string propertyName, Matrix4x4 matrix);
        public extern bool SetPass(int pass);
        public extern void SetTexture(int nameID, Texture texture);
        public extern void SetTexture(string propertyName, Texture texture);
        public extern void SetTextureOffset(string propertyName, Vector2 offset);
        public extern void SetTextureScale(string propertyName, Vector2 scale);
        public extern void SetVector(int nameID, Vector4 vector);
        public extern void SetVector(string propertyName, Vector4 vector);
    }
}
 
namespace System.Collections
{
    [Bridge.FileName("csw")]
    public class Hashtable : IEnumerable, System.ICloneable, System.Runtime.Serialization.ISerializable, ICollection, IDictionary, System.Runtime.Serialization.IDeserializationCallback
    {
        public extern Hashtable();
        public extern Hashtable(IDictionary d);
        public extern Hashtable(IDictionary d, IEqualityComparer equalityComparer);
        public extern Hashtable(IDictionary d, float loadFactor);
        public extern Hashtable(IDictionary d, float loadFactor, IEqualityComparer equalityComparer);
        public extern Hashtable(IEqualityComparer equalityComparer);
        public extern Hashtable(int capacity);
        public extern Hashtable(int capacity, IEqualityComparer equalityComparer);
        public extern Hashtable(int capacity, float loadFactor);
        public extern Hashtable(int capacity, float loadFactor, IEqualityComparer equalityComparer);
         
        public virtual int Count { get { return default(int); } }
        public virtual bool IsFixedSize { get { return default(bool); } }
        public virtual bool IsReadOnly { get { return default(bool); } }
        public virtual bool IsSynchronized { get { return default(bool); } }
        public virtual ICollection Keys { get { return default(ICollection); } }
        public virtual object SyncRoot { get { return default(object); } }
        public virtual ICollection Values { get { return default(ICollection); } }
         
        public virtual object this[object key] { get { return default(object); } set {} }
         
        public extern virtual void Add(object key, object value);
        public extern virtual void Clear();
        public extern virtual object Clone();
        public extern virtual bool Contains(object key);
        public extern virtual bool ContainsKey(object key);
        public extern virtual bool ContainsValue(object value);
        public extern virtual void CopyTo(System.Array array, int arrayIndex);
        public extern virtual IDictionaryEnumerator GetEnumerator();
        public extern virtual void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context);
        public extern virtual void OnDeserialization(object sender);
        public extern virtual void Remove(object key);
        public static extern Hashtable Synchronized(Hashtable table);
        extern IEnumerator IEnumerable.GetEnumerator();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class GameObject : Object
    {
        public extern GameObject();
        public extern GameObject(string name);
        public extern GameObject(string name, params System.Type[] components);
         
        public bool activeInHierarchy { get { return default(bool); } }
        public bool activeSelf { get { return default(bool); } }
        public Animation animation { get { return default(Animation); } }
        public AudioSource audio { get { return default(AudioSource); } }
        public Camera camera { get { return default(Camera); } }
        public Collider collider { get { return default(Collider); } }
        public Collider2D collider2D { get { return default(Collider2D); } }
        public ConstantForce constantForce { get { return default(ConstantForce); } }
        public GameObject gameObject { get { return default(GameObject); } }
        public GUIText guiText { get { return default(GUIText); } }
        public GUITexture guiTexture { get { return default(GUITexture); } }
        public HingeJoint hingeJoint { get { return default(HingeJoint); } }
        public bool isStatic { get { return default(bool); } set {} }
        public int layer { get { return default(int); } set {} }
        public Light light { get { return default(Light); } }
        public ParticleEmitter particleEmitter { get { return default(ParticleEmitter); } }
        public ParticleSystem particleSystem { get { return default(ParticleSystem); } }
        public Renderer renderer { get { return default(Renderer); } }
        public Rigidbody rigidbody { get { return default(Rigidbody); } }
        public Rigidbody2D rigidbody2D { get { return default(Rigidbody2D); } }
        public string tag { get { return default(string); } set {} }
        public Transform transform { get { return default(Transform); } }
         
         
        public extern T AddComponent<T>();
        public extern Component AddComponent(string className);
        public extern Component AddComponent(System.Type componentType);
        public extern void BroadcastMessage(string methodName);
        public extern void BroadcastMessage(string methodName, object parameter);
        public extern void BroadcastMessage(string methodName, object parameter, SendMessageOptions options);
        public extern void BroadcastMessage(string methodName, SendMessageOptions options);
        public extern bool CompareTag(string tag);
        public extern T GetComponent<T>();
        public extern Component GetComponent(string type);
        public extern Component GetComponent(System.Type type);
        public extern T GetComponentInChildren<T>();
        public extern Component GetComponentInChildren(System.Type type);
        public extern T GetComponentInParent<T>();
        public extern Component GetComponentInParent(System.Type type);
        public extern T[] GetComponents<T>();
        public extern void GetComponents(System.Type type, System.Collections.Generic.List<UnityEngine.Component> results);
        public extern void GetComponents<T>(System.Collections.Generic.List<T> results);
        public extern Component[] GetComponents(System.Type type);
        public extern T[] GetComponentsInChildren<T>();
        public extern T[] GetComponentsInChildren<T>(bool includeInactive);
        public extern void GetComponentsInChildren<T>(bool includeInactive, System.Collections.Generic.List<T> results);
        public extern void GetComponentsInChildren<T>(System.Collections.Generic.List<T> results);
        public extern Component[] GetComponentsInChildren(System.Type type);
        public extern Component[] GetComponentsInChildren(System.Type type, bool includeInactive);
        public extern T[] GetComponentsInParent<T>();
        public extern T[] GetComponentsInParent<T>(bool includeInactive);
        public extern void GetComponentsInParent<T>(bool includeInactive, System.Collections.Generic.List<T> results);
        public extern Component[] GetComponentsInParent(System.Type type);
        public extern Component[] GetComponentsInParent(System.Type type, bool includeInactive);
        public extern void SampleAnimation(AnimationClip animation, float time);
        public extern void SendMessage(string methodName);
        public extern void SendMessage(string methodName, object value);
        public extern void SendMessage(string methodName, object value, SendMessageOptions options);
        public extern void SendMessage(string methodName, SendMessageOptions options);
        public extern void SendMessageUpwards(string methodName);
        public extern void SendMessageUpwards(string methodName, object value);
        public extern void SendMessageUpwards(string methodName, object value, SendMessageOptions options);
        public extern void SendMessageUpwards(string methodName, SendMessageOptions options);
        public extern void SetActive(bool value);
        public static extern GameObject CreatePrimitive(PrimitiveType type);
        public static extern GameObject Find(string name);
        public static extern GameObject[] FindGameObjectsWithTag(string tag);
        public static extern GameObject FindGameObjectWithTag(string tag);
        public static extern GameObject FindWithTag(string tag);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AudioClip : Object
    {
            public delegate void PCMReaderCallback(float[] data);
            public delegate void PCMSetPositionCallback(int position);
        public extern AudioClip();
         
        public int channels { get { return default(int); } }
        public int frequency { get { return default(int); } }
        public bool isReadyToPlay { get { return default(bool); } }
        public float length { get { return default(float); } }
        public int samples { get { return default(int); } }
         
         
        public extern void GetData(float[] data, int offsetSamples);
        public extern void SetData(float[] data, int offsetSamples);
        public static extern AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream);
        public static extern AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, AudioClip.PCMReaderCallback pcmreadercallback);
        public static extern AudioClip Create(string name, int lengthSamples, int channels, int frequency, bool _3D, bool stream, AudioClip.PCMReaderCallback pcmreadercallback, AudioClip.PCMSetPositionCallback pcmsetpositioncallback);
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public interface ILayoutGroup : ILayoutController
    {
    }
}
 
namespace UnityEngine.Events
{
    [Bridge.FileName("csw")]
    public class UnityEventBase : UnityEngine.ISerializationCallbackReceiver
    {
        public extern int GetPersistentEventCount();
        public extern string GetPersistentMethodName(int index);
        public extern UnityEngine.Object GetPersistentTarget(int index);
        public extern void RemoveAllListeners();
        public extern void SetPersistentListenerState(int index, UnityEventCallState state);
        public extern override string ToString();
        public static extern System.Reflection.MethodInfo GetValidMethodInfo(object obj, string functionName, System.Type[] argumentTypes);
        public extern void OnAfterDeserialize();
        public extern void OnBeforeSerialize();
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface ISelectHandler : IEventSystemHandler
    {
        void OnSelect(BaseEventData eventData);
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface IPointerUpHandler : IEventSystemHandler
    {
        void OnPointerUp(PointerEventData eventData);
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface IPointerDownHandler : IEventSystemHandler
    {
        void OnPointerDown(PointerEventData eventData);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class WaitForSeconds : YieldInstruction
    {
        public extern WaitForSeconds(float seconds);
         
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface IMoveHandler : IEventSystemHandler
    {
        void OnMove(AxisEventData eventData);
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface IDeselectHandler : IEventSystemHandler
    {
        void OnDeselect(BaseEventData eventData);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Component : Object
    {
        public extern Component();
         
        public Animation animation { get { return default(Animation); } }
        public AudioSource audio { get { return default(AudioSource); } }
        public Camera camera { get { return default(Camera); } }
        public Collider collider { get { return default(Collider); } }
        public Collider2D collider2D { get { return default(Collider2D); } }
        public ConstantForce constantForce { get { return default(ConstantForce); } }
        public GameObject gameObject { get { return default(GameObject); } }
        public GUIText guiText { get { return default(GUIText); } }
        public GUITexture guiTexture { get { return default(GUITexture); } }
        public HingeJoint hingeJoint { get { return default(HingeJoint); } }
        public Light light { get { return default(Light); } }
        public ParticleEmitter particleEmitter { get { return default(ParticleEmitter); } }
        public ParticleSystem particleSystem { get { return default(ParticleSystem); } }
        public Renderer renderer { get { return default(Renderer); } }
        public Rigidbody rigidbody { get { return default(Rigidbody); } }
        public Rigidbody2D rigidbody2D { get { return default(Rigidbody2D); } }
        public string tag { get { return default(string); } set {} }
        public Transform transform { get { return default(Transform); } }
         
         
        public extern void BroadcastMessage(string methodName);
        public extern void BroadcastMessage(string methodName, object parameter);
        public extern void BroadcastMessage(string methodName, object parameter, SendMessageOptions options);
        public extern void BroadcastMessage(string methodName, SendMessageOptions options);
        public extern bool CompareTag(string tag);
        public extern T GetComponent<T>();
        public extern Component GetComponent(string type);
        public extern Component GetComponent(System.Type type);
        public extern T GetComponentInChildren<T>();
        public extern Component GetComponentInChildren(System.Type t);
        public extern T GetComponentInParent<T>();
        public extern Component GetComponentInParent(System.Type t);
        public extern T[] GetComponents<T>();
        public extern void GetComponents(System.Type type, System.Collections.Generic.List<UnityEngine.Component> results);
        public extern void GetComponents<T>(System.Collections.Generic.List<T> results);
        public extern Component[] GetComponents(System.Type type);
        public extern T[] GetComponentsInChildren<T>();
        public extern T[] GetComponentsInChildren<T>(bool includeInactive);
        public extern void GetComponentsInChildren<T>(bool includeInactive, System.Collections.Generic.List<T> result);
        public extern void GetComponentsInChildren<T>(System.Collections.Generic.List<T> results);
        public extern Component[] GetComponentsInChildren(System.Type t);
        public extern Component[] GetComponentsInChildren(System.Type t, bool includeInactive);
        public extern T[] GetComponentsInParent<T>();
        public extern T[] GetComponentsInParent<T>(bool includeInactive);
        public extern Component[] GetComponentsInParent(System.Type t);
        public extern Component[] GetComponentsInParent(System.Type t, bool includeInactive);
        public extern void SendMessage(string methodName);
        public extern void SendMessage(string methodName, object value);
        public extern void SendMessage(string methodName, object value, SendMessageOptions options);
        public extern void SendMessage(string methodName, SendMessageOptions options);
        public extern void SendMessageUpwards(string methodName);
        public extern void SendMessageUpwards(string methodName, object value);
        public extern void SendMessageUpwards(string methodName, object value, SendMessageOptions options);
        public extern void SendMessageUpwards(string methodName, SendMessageOptions options);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Sprite : Object
    {
        public extern Sprite();
         
        public Vector4 border { get { return default(Vector4); } }
        public Bounds bounds { get { return default(Bounds); } }
        public bool packed { get { return default(bool); } }
        public SpritePackingMode packingMode { get { return default(SpritePackingMode); } }
        public SpritePackingRotation packingRotation { get { return default(SpritePackingRotation); } }
        public float pixelsPerUnit { get { return default(float); } }
        public Rect rect { get { return default(Rect); } }
        public Texture2D texture { get { return default(Texture2D); } }
        public Rect textureRect { get { return default(Rect); } }
        public Vector2 textureRectOffset { get { return default(Vector2); } }
         
         
        public static extern Sprite Create(Texture2D texture, Rect rect, Vector2 pivot);
        public static extern Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit);
        public static extern Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude);
        public static extern Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType);
        public static extern Sprite Create(Texture2D texture, Rect rect, Vector2 pivot, float pixelsPerUnit, uint extrude, SpriteMeshType meshType, Vector4 border);
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface IPointerEnterHandler : IEventSystemHandler
    {
        void OnPointerEnter(PointerEventData eventData);
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface IPointerExitHandler : IEventSystemHandler
    {
        void OnPointerExit(PointerEventData eventData);
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public interface ISubmitHandler : IEventSystemHandler
    {
        void OnSubmit(BaseEventData eventData);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Rigidbody : Component
    {
        public extern Rigidbody();
         
        public float angularDrag { get { return default(float); } set {} }
        public Vector3 angularVelocity { get { return default(Vector3); } set {} }
        public Vector3 centerOfMass { get { return default(Vector3); } set {} }
        public CollisionDetectionMode collisionDetectionMode { get { return default(CollisionDetectionMode); } set {} }
        public RigidbodyConstraints constraints { get { return default(RigidbodyConstraints); } set {} }
        public bool detectCollisions { get { return default(bool); } set {} }
        public float drag { get { return default(float); } set {} }
        public bool freezeRotation { get { return default(bool); } set {} }
        public Vector3 inertiaTensor { get { return default(Vector3); } set {} }
        public Quaternion inertiaTensorRotation { get { return default(Quaternion); } set {} }
        public RigidbodyInterpolation interpolation { get { return default(RigidbodyInterpolation); } set {} }
        public bool isKinematic { get { return default(bool); } set {} }
        public float mass { get { return default(float); } set {} }
        public float maxAngularVelocity { get { return default(float); } set {} }
        public Vector3 position { get { return default(Vector3); } set {} }
        public Quaternion rotation { get { return default(Quaternion); } set {} }
        public float sleepAngularVelocity { get { return default(float); } set {} }
        public float sleepVelocity { get { return default(float); } set {} }
        public int solverIterationCount { get { return default(int); } set {} }
        public bool useConeFriction { get { return default(bool); } set {} }
        public bool useGravity { get { return default(bool); } set {} }
        public Vector3 velocity { get { return default(Vector3); } set {} }
        public Vector3 worldCenterOfMass { get { return default(Vector3); } }
         
         
        public extern void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius);
        public extern void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier);
        public extern void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier, ForceMode mode);
        public extern void AddForce(float x, float y, float z);
        public extern void AddForce(float x, float y, float z, ForceMode mode);
        public extern void AddForce(Vector3 force);
        public extern void AddForce(Vector3 force, ForceMode mode);
        public extern void AddForceAtPosition(Vector3 force, Vector3 position);
        public extern void AddForceAtPosition(Vector3 force, Vector3 position, ForceMode mode);
        public extern void AddRelativeForce(float x, float y, float z);
        public extern void AddRelativeForce(float x, float y, float z, ForceMode mode);
        public extern void AddRelativeForce(Vector3 force);
        public extern void AddRelativeForce(Vector3 force, ForceMode mode);
        public extern void AddRelativeTorque(float x, float y, float z);
        public extern void AddRelativeTorque(float x, float y, float z, ForceMode mode);
        public extern void AddRelativeTorque(Vector3 torque);
        public extern void AddRelativeTorque(Vector3 torque, ForceMode mode);
        public extern void AddTorque(float x, float y, float z);
        public extern void AddTorque(float x, float y, float z, ForceMode mode);
        public extern void AddTorque(Vector3 torque);
        public extern void AddTorque(Vector3 torque, ForceMode mode);
        public extern Vector3 ClosestPointOnBounds(Vector3 position);
        public extern Vector3 GetPointVelocity(Vector3 worldPoint);
        public extern Vector3 GetRelativePointVelocity(Vector3 relativePoint);
        public extern bool IsSleeping();
        public extern void MovePosition(Vector3 position);
        public extern void MoveRotation(Quaternion rot);
        public extern void SetDensity(float density);
        public extern void Sleep();
        public extern bool SweepTest(Vector3 direction, out RaycastHit hitInfo);
        public extern bool SweepTest(Vector3 direction, out RaycastHit hitInfo, float distance);
        public extern RaycastHit[] SweepTestAll(Vector3 direction);
        public extern RaycastHit[] SweepTestAll(Vector3 direction, float distance);
        public extern void WakeUp();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Transform : Component, System.Collections.IEnumerable
    {
        public int childCount { get { return default(int); } }
        public Vector3 eulerAngles { get { return default(Vector3); } set {} }
        public Vector3 forward { get { return default(Vector3); } set {} }
        public bool hasChanged { get { return default(bool); } set {} }
        public Vector3 localEulerAngles { get { return default(Vector3); } set {} }
        public Vector3 localPosition { get { return default(Vector3); } set {} }
        public Quaternion localRotation { get { return default(Quaternion); } set {} }
        public Vector3 localScale { get { return default(Vector3); } set {} }
        public Matrix4x4 localToWorldMatrix { get { return default(Matrix4x4); } }
        public Vector3 lossyScale { get { return default(Vector3); } }
        public Transform parent { get { return default(Transform); } set {} }
        public Vector3 position { get { return default(Vector3); } set {} }
        public Vector3 right { get { return default(Vector3); } set {} }
        public Transform root { get { return default(Transform); } }
        public Quaternion rotation { get { return default(Quaternion); } set {} }
        public Vector3 up { get { return default(Vector3); } set {} }
        public Matrix4x4 worldToLocalMatrix { get { return default(Matrix4x4); } }
         
         
        public extern void DetachChildren();
        public extern Transform Find(string name);
        public extern Transform FindChild(string name);
        public extern Transform GetChild(int index);
        public extern virtual System.Collections.IEnumerator GetEnumerator();
        public extern int GetSiblingIndex();
        public extern Vector3 InverseTransformDirection(float x, float y, float z);
        public extern Vector3 InverseTransformDirection(Vector3 direction);
        public extern Vector3 InverseTransformPoint(float x, float y, float z);
        public extern Vector3 InverseTransformPoint(Vector3 position);
        public extern Vector3 InverseTransformVector(float x, float y, float z);
        public extern Vector3 InverseTransformVector(Vector3 vector);
        public extern bool IsChildOf(Transform parent);
        public extern void LookAt(Transform target);
        public extern void LookAt(Transform target, Vector3 worldUp);
        public extern void LookAt(Vector3 worldPosition);
        public extern void LookAt(Vector3 worldPosition, Vector3 worldUp);
        public extern void Rotate(float xAngle, float yAngle, float zAngle);
        public extern void Rotate(float xAngle, float yAngle, float zAngle, Space relativeTo);
        public extern void Rotate(Vector3 eulerAngles);
        public extern void Rotate(Vector3 axis, float angle);
        public extern void Rotate(Vector3 axis, float angle, Space relativeTo);
        public extern void Rotate(Vector3 eulerAngles, Space relativeTo);
        public extern void RotateAround(Vector3 point, Vector3 axis, float angle);
        public extern void SetAsFirstSibling();
        public extern void SetAsLastSibling();
        public extern void SetParent(Transform parent);
        public extern void SetParent(Transform parent, bool worldPositionStays);
        public extern void SetSiblingIndex(int index);
        public extern Vector3 TransformDirection(float x, float y, float z);
        public extern Vector3 TransformDirection(Vector3 direction);
        public extern Vector3 TransformPoint(float x, float y, float z);
        public extern Vector3 TransformPoint(Vector3 position);
        public extern Vector3 TransformVector(float x, float y, float z);
        public extern Vector3 TransformVector(Vector3 vector);
        public extern void Translate(float x, float y, float z);
        public extern void Translate(float x, float y, float z, Space relativeTo);
        public extern void Translate(float x, float y, float z, Transform relativeTo);
        public extern void Translate(Vector3 translation);
        public extern void Translate(Vector3 translation, Space relativeTo);
        public extern void Translate(Vector3 translation, Transform relativeTo);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Rigidbody2D : Component
    {
        public extern Rigidbody2D();
         
        public float angularDrag { get { return default(float); } set {} }
        public float angularVelocity { get { return default(float); } set {} }
        public Vector2 centerOfMass { get { return default(Vector2); } set {} }
        public CollisionDetectionMode2D collisionDetectionMode { get { return default(CollisionDetectionMode2D); } set {} }
        public float drag { get { return default(float); } set {} }
        public bool fixedAngle { get { return default(bool); } set {} }
        public float gravityScale { get { return default(float); } set {} }
        public float inertia { get { return default(float); } set {} }
        public RigidbodyInterpolation2D interpolation { get { return default(RigidbodyInterpolation2D); } set {} }
        public bool isKinematic { get { return default(bool); } set {} }
        public float mass { get { return default(float); } set {} }
        public Vector2 position { get { return default(Vector2); } set {} }
        public float rotation { get { return default(float); } set {} }
        public bool simulated { get { return default(bool); } set {} }
        public RigidbodySleepMode2D sleepMode { get { return default(RigidbodySleepMode2D); } set {} }
        public Vector2 velocity { get { return default(Vector2); } set {} }
        public Vector2 worldCenterOfMass { get { return default(Vector2); } }
         
         
        public extern void AddForce(Vector2 force);
        public extern void AddForce(Vector2 force, ForceMode2D mode);
        public extern void AddForceAtPosition(Vector2 force, Vector2 position);
        public extern void AddForceAtPosition(Vector2 force, Vector2 position, ForceMode2D mode);
        public extern void AddRelativeForce(Vector2 relativeForce);
        public extern void AddRelativeForce(Vector2 relativeForce, ForceMode2D mode);
        public extern void AddTorque(float torque);
        public extern void AddTorque(float torque, ForceMode2D mode);
        public extern Vector2 GetPoint(Vector2 point);
        public extern Vector2 GetPointVelocity(Vector2 point);
        public extern Vector2 GetRelativePoint(Vector2 relativePoint);
        public extern Vector2 GetRelativePointVelocity(Vector2 relativePoint);
        public extern Vector2 GetRelativeVector(Vector2 relativeVector);
        public extern Vector2 GetVector(Vector2 vector);
        public extern bool IsAwake();
        public extern bool IsSleeping();
        public extern void MovePosition(Vector2 position);
        public extern void MoveRotation(float angle);
        public extern void Sleep();
        public extern void WakeUp();
    }
}
 
namespace UnityEngine.Events
{
    [Bridge.FileName("csw")]
    public class UnityEvent : UnityEventBase
    {
        public extern UnityEvent();
         
        public extern void AddListener(UnityAction call);
        public extern void Invoke();
        public extern void RemoveListener(UnityAction call);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class ParticleSystem : Component
    {
            [Bridge.FileName("csw")]
            public struct Particle
            {
                 
                public float angularVelocity { get { return default(float); } set {} }
                public Vector3 axisOfRotation { get { return default(Vector3); } set {} }
                public Color32 color { get { return default(Color32); } set {} }
                public float lifetime { get { return default(float); } set {} }
                public Vector3 position { get { return default(Vector3); } set {} }
                public uint randomSeed { get { return default(uint); } set {} }
                public float rotation { get { return default(float); } set {} }
                public float size { get { return default(float); } set {} }
                public float startLifetime { get { return default(float); } set {} }
                public Vector3 velocity { get { return default(Vector3); } set {} }
                 
                 
            }
            [Bridge.FileName("csw")]
            public struct CollisionEvent
            {
                 
                public Collider collider { get { return default(Collider); } }
                public Vector3 intersection { get { return default(Vector3); } }
                public Vector3 normal { get { return default(Vector3); } }
                public Vector3 velocity { get { return default(Vector3); } }
                 
                 
            }
        public extern ParticleSystem();
         
        public float duration { get { return default(float); } }
        public float emissionRate { get { return default(float); } set {} }
        public bool enableEmission { get { return default(bool); } set {} }
        public float gravityModifier { get { return default(float); } set {} }
        public bool isPaused { get { return default(bool); } }
        public bool isPlaying { get { return default(bool); } }
        public bool isStopped { get { return default(bool); } }
        public bool loop { get { return default(bool); } set {} }
        public int maxParticles { get { return default(int); } set {} }
        public int particleCount { get { return default(int); } }
        public float playbackSpeed { get { return default(float); } set {} }
        public bool playOnAwake { get { return default(bool); } set {} }
        public uint randomSeed { get { return default(uint); } set {} }
        public int safeCollisionEventSize { get { return default(int); } }
        public ParticleSystemSimulationSpace simulationSpace { get { return default(ParticleSystemSimulationSpace); } set {} }
        public Color startColor { get { return default(Color); } set {} }
        public float startDelay { get { return default(float); } set {} }
        public float startLifetime { get { return default(float); } set {} }
        public float startRotation { get { return default(float); } set {} }
        public float startSize { get { return default(float); } set {} }
        public float startSpeed { get { return default(float); } set {} }
        public float time { get { return default(float); } set {} }
         
         
        public extern void Clear();
        public extern void Clear(bool withChildren);
        public extern void Emit(int count);
        public extern void Emit(ParticleSystem.Particle particle);
        public extern void Emit(Vector3 position, Vector3 velocity, float size, float lifetime, Color32 color);
        public extern int GetCollisionEvents(GameObject go, ParticleSystem.CollisionEvent[] collisionEvents);
        public extern int GetParticles(ParticleSystem.Particle[] particles);
        public extern bool IsAlive();
        public extern bool IsAlive(bool withChildren);
        public extern void Pause();
        public extern void Pause(bool withChildren);
        public extern void Play();
        public extern void Play(bool withChildren);
        public extern void SetParticles(ParticleSystem.Particle[] particles, int size);
        public extern void Simulate(float t);
        public extern void Simulate(float t, bool withChildren);
        public extern void Simulate(float t, bool withChildren, bool restart);
        public extern void Stop();
        public extern void Stop(bool withChildren);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Collider : Component
    {
        public extern Collider();
         
        public Rigidbody attachedRigidbody { get { return default(Rigidbody); } }
        public Bounds bounds { get { return default(Bounds); } }
        public bool enabled { get { return default(bool); } set {} }
        public bool isTrigger { get { return default(bool); } set {} }
        public PhysicMaterial material { get { return default(PhysicMaterial); } set {} }
        public PhysicMaterial sharedMaterial { get { return default(PhysicMaterial); } set {} }
         
         
        public extern Vector3 ClosestPointOnBounds(Vector3 position);
        public extern bool Raycast(Ray ray, out RaycastHit hitInfo, float distance);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Renderer : Component
    {
        public extern Renderer();
         
        public Bounds bounds { get { return default(Bounds); } }
        public bool castShadows { get { return default(bool); } set {} }
        public bool enabled { get { return default(bool); } set {} }
        public bool isPartOfStaticBatch { get { return default(bool); } }
        public bool isVisible { get { return default(bool); } }
        public int lightmapIndex { get { return default(int); } set {} }
        public Vector4 lightmapTilingOffset { get { return default(Vector4); } set {} }
        public Transform lightProbeAnchor { get { return default(Transform); } set {} }
        public Matrix4x4 localToWorldMatrix { get { return default(Matrix4x4); } }
        public Material material { get { return default(Material); } set {} }
        public Material[] materials { get { return default(Material[]); } set {} }
        public bool receiveShadows { get { return default(bool); } set {} }
        public Material sharedMaterial { get { return default(Material); } set {} }
        public Material[] sharedMaterials { get { return default(Material[]); } set {} }
        public int sortingLayerID { get { return default(int); } set {} }
        public string sortingLayerName { get { return default(string); } set {} }
        public int sortingOrder { get { return default(int); } set {} }
        public bool useLightProbes { get { return default(bool); } set {} }
        public Matrix4x4 worldToLocalMatrix { get { return default(Matrix4x4); } }
         
         
        public extern void GetPropertyBlock(MaterialPropertyBlock dest);
        public extern void Render(int material);
        public extern void SetPropertyBlock(MaterialPropertyBlock properties);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Behaviour : Component
    {
        public extern Behaviour();
         
        public bool enabled { get { return default(bool); } set {} }
        public bool isActiveAndEnabled { get { return default(bool); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Light : Behaviour
    {
        public extern Light();
         
        public bool alreadyLightmapped { get { return default(bool); } set {} }
        public Color color { get { return default(Color); } set {} }
        public Texture cookie { get { return default(Texture); } set {} }
        public float cookieSize { get { return default(float); } set {} }
        public int cullingMask { get { return default(int); } set {} }
        public Flare flare { get { return default(Flare); } set {} }
        public float intensity { get { return default(float); } set {} }
        public float range { get { return default(float); } set {} }
        public LightRenderMode renderMode { get { return default(LightRenderMode); } set {} }
        public float shadowBias { get { return default(float); } set {} }
        public LightShadows shadows { get { return default(LightShadows); } set {} }
        public float shadowSoftness { get { return default(float); } set {} }
        public float shadowSoftnessFade { get { return default(float); } set {} }
        public float shadowStrength { get { return default(float); } set {} }
        public float spotAngle { get { return default(float); } set {} }
        public LightType type { get { return default(LightType); } set {} }
         
         
        public static extern Light[] GetLights(LightType type, int layer);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class BoxCollider : Collider
    {
        public extern BoxCollider();
         
        public Vector3 center { get { return default(Vector3); } set {} }
        public Vector3 size { get { return default(Vector3); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Collider2D : Behaviour
    {
        public extern Collider2D();
         
        public Rigidbody2D attachedRigidbody { get { return default(Rigidbody2D); } }
        public Bounds bounds { get { return default(Bounds); } }
        public bool isTrigger { get { return default(bool); } set {} }
        public int shapeCount { get { return default(int); } }
        public PhysicsMaterial2D sharedMaterial { get { return default(PhysicsMaterial2D); } set {} }
         
         
        public extern bool OverlapPoint(Vector2 point);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class CapsuleCollider : Collider
    {
        public extern CapsuleCollider();
         
        public Vector3 center { get { return default(Vector3); } set {} }
        public int direction { get { return default(int); } set {} }
        public float height { get { return default(float); } set {} }
        public float radius { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class MonoBehaviour : Behaviour
    {
        public extern MonoBehaviour();
         
        public bool useGUILayout { get { return default(bool); } set {} }
         
         
        public extern void CancelInvoke();
        public extern void CancelInvoke(string methodName);
        public extern void Invoke(string methodName, float time);
        public extern void InvokeRepeating(string methodName, float time, float repeatRate);
        public extern bool IsInvoking();
        public extern bool IsInvoking(string methodName);
        public extern Coroutine StartCoroutine(System.Collections.IEnumerator routine);
        public extern Coroutine StartCoroutine(string methodName);
        public extern Coroutine StartCoroutine(string methodName, object value);
        public extern Coroutine StartCoroutine_Auto(System.Collections.IEnumerator routine);
        public extern void StopAllCoroutines();
        public extern void StopCoroutine(System.Collections.IEnumerator routine);
        public extern void StopCoroutine(string methodName);
        public extern void StopCoroutine(Coroutine routine);
        public static extern void print(object message);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class NavMeshAgent : Behaviour
    {
        public extern NavMeshAgent();
         
        public float acceleration { get { return default(float); } set {} }
        public float angularSpeed { get { return default(float); } set {} }
        public bool autoBraking { get { return default(bool); } set {} }
        public bool autoRepath { get { return default(bool); } set {} }
        public bool autoTraverseOffMeshLink { get { return default(bool); } set {} }
        public int avoidancePriority { get { return default(int); } set {} }
        public float baseOffset { get { return default(float); } set {} }
        public OffMeshLinkData currentOffMeshLinkData { get { return default(OffMeshLinkData); } }
        public Vector3 desiredVelocity { get { return default(Vector3); } }
        public Vector3 destination { get { return default(Vector3); } set {} }
        public bool hasPath { get { return default(bool); } }
        public float height { get { return default(float); } set {} }
        public bool isOnOffMeshLink { get { return default(bool); } }
        public bool isPathStale { get { return default(bool); } }
        public OffMeshLinkData nextOffMeshLinkData { get { return default(OffMeshLinkData); } }
        public Vector3 nextPosition { get { return default(Vector3); } set {} }
        public ObstacleAvoidanceType obstacleAvoidanceType { get { return default(ObstacleAvoidanceType); } set {} }
        public NavMeshPath path { get { return default(NavMeshPath); } set {} }
        public Vector3 pathEndPosition { get { return default(Vector3); } }
        public bool pathPending { get { return default(bool); } }
        public NavMeshPathStatus pathStatus { get { return default(NavMeshPathStatus); } }
        public float radius { get { return default(float); } set {} }
        public float remainingDistance { get { return default(float); } }
        public float speed { get { return default(float); } set {} }
        public Vector3 steeringTarget { get { return default(Vector3); } }
        public float stoppingDistance { get { return default(float); } set {} }
        public bool updatePosition { get { return default(bool); } set {} }
        public bool updateRotation { get { return default(bool); } set {} }
        public Vector3 velocity { get { return default(Vector3); } set {} }
        public int walkableMask { get { return default(int); } set {} }
         
         
        public extern void ActivateCurrentOffMeshLink(bool activated);
        public extern bool CalculatePath(Vector3 targetPosition, NavMeshPath path);
        public extern void CompleteOffMeshLink();
        public extern bool FindClosestEdge(out NavMeshHit hit);
        public extern float GetLayerCost(int layer);
        public extern void Move(Vector3 offset);
        public extern bool Raycast(Vector3 targetPosition, out NavMeshHit hit);
        public extern void ResetPath();
        public extern void Resume();
        public extern bool SamplePathPosition(int passableMask, float maxDistance, out NavMeshHit hit);
        public extern bool SetDestination(Vector3 target);
        public extern void SetLayerCost(int layer, float cost);
        public extern bool SetPath(NavMeshPath path);
        public extern void Stop();
        public extern void Stop(bool stopUpdates);
        public extern bool Warp(Vector3 newPosition);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class SpriteRenderer : Renderer
    {
        public extern SpriteRenderer();
         
        public Color color { get { return default(Color); } set {} }
        public Sprite sprite { get { return default(Sprite); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class GUIElement : Behaviour
    {
        public extern GUIElement();
         
        public extern Rect GetScreenRect();
        public extern Rect GetScreenRect(Camera camera);
        public extern bool HitTest(Vector3 screenPosition);
        public extern bool HitTest(Vector3 screenPosition, Camera camera);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class ParticleSystemRenderer : Renderer
    {
        public extern ParticleSystemRenderer();
         
        public float cameraVelocityScale { get { return default(float); } set {} }
        public float lengthScale { get { return default(float); } set {} }
        public float maxParticleSize { get { return default(float); } set {} }
        public Mesh mesh { get { return default(Mesh); } set {} }
        public ParticleSystemRenderMode renderMode { get { return default(ParticleSystemRenderMode); } set {} }
        public float velocityScale { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AudioSource : Behaviour
    {
        public extern AudioSource();
         
        public bool bypassEffects { get { return default(bool); } set {} }
        public bool bypassListenerEffects { get { return default(bool); } set {} }
        public bool bypassReverbZones { get { return default(bool); } set {} }
        public AudioClip clip { get { return default(AudioClip); } set {} }
        public float dopplerLevel { get { return default(float); } set {} }
        public bool ignoreListenerPause { get { return default(bool); } set {} }
        public bool ignoreListenerVolume { get { return default(bool); } set {} }
        public bool isPlaying { get { return default(bool); } }
        public bool loop { get { return default(bool); } set {} }
        public float maxDistance { get { return default(float); } set {} }
        public float minDistance { get { return default(float); } set {} }
        public bool mute { get { return default(bool); } set {} }
        public float pan { get { return default(float); } set {} }
        public float panLevel { get { return default(float); } set {} }
        public float pitch { get { return default(float); } set {} }
        public bool playOnAwake { get { return default(bool); } set {} }
        public int priority { get { return default(int); } set {} }
        public AudioRolloffMode rolloffMode { get { return default(AudioRolloffMode); } set {} }
        public float spread { get { return default(float); } set {} }
        public float time { get { return default(float); } set {} }
        public int timeSamples { get { return default(int); } set {} }
        public AudioVelocityUpdateMode velocityUpdateMode { get { return default(AudioVelocityUpdateMode); } set {} }
        public float volume { get { return default(float); } set {} }
         
         
        public extern void GetOutputData(float[] samples, int channel);
        public extern void GetSpectrumData(float[] samples, int channel, FFTWindow window);
        public extern void Pause();
        public extern void Play();
        public extern void Play(ulong delay);
        public extern void PlayDelayed(float delay);
        public extern void PlayOneShot(AudioClip clip);
        public extern void PlayOneShot(AudioClip clip, float volumeScale);
        public extern void PlayScheduled(double time);
        public extern void SetScheduledEndTime(double time);
        public extern void SetScheduledStartTime(double time);
        public extern void Stop();
        public static extern void PlayClipAtPoint(AudioClip clip, Vector3 position);
        public static extern void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Camera : Behaviour
    {
        public extern Camera();
         
        public RenderingPath actualRenderingPath { get { return default(RenderingPath); } }
        public float aspect { get { return default(float); } set {} }
        public Color backgroundColor { get { return default(Color); } set {} }
        public Matrix4x4 cameraToWorldMatrix { get { return default(Matrix4x4); } }
        public CameraClearFlags clearFlags { get { return default(CameraClearFlags); } set {} }
        public bool clearStencilAfterLightingPass { get { return default(bool); } set {} }
        public int cullingMask { get { return default(int); } set {} }
        public float depth { get { return default(float); } set {} }
        public DepthTextureMode depthTextureMode { get { return default(DepthTextureMode); } set {} }
        public int eventMask { get { return default(int); } set {} }
        public float farClipPlane { get { return default(float); } set {} }
        public float fieldOfView { get { return default(float); } set {} }
        public bool hdr { get { return default(bool); } set {} }
        public bool isOrthoGraphic { get { return default(bool); } set {} }
        public float[] layerCullDistances { get { return default(float[]); } set {} }
        public bool layerCullSpherical { get { return default(bool); } set {} }
        public float nearClipPlane { get { return default(float); } set {} }
        public bool orthographic { get { return default(bool); } set {} }
        public float orthographicSize { get { return default(float); } set {} }
        public float pixelHeight { get { return default(float); } }
        public Rect pixelRect { get { return default(Rect); } set {} }
        public float pixelWidth { get { return default(float); } }
        public Matrix4x4 projectionMatrix { get { return default(Matrix4x4); } set {} }
        public Rect rect { get { return default(Rect); } set {} }
        public RenderingPath renderingPath { get { return default(RenderingPath); } set {} }
        public float stereoConvergence { get { return default(float); } set {} }
        public bool stereoEnabled { get { return default(bool); } }
        public float stereoSeparation { get { return default(float); } set {} }
        public RenderTexture targetTexture { get { return default(RenderTexture); } set {} }
        public TransparencySortMode transparencySortMode { get { return default(TransparencySortMode); } set {} }
        public bool useOcclusionCulling { get { return default(bool); } set {} }
        public Vector3 velocity { get { return default(Vector3); } }
        public Matrix4x4 worldToCameraMatrix { get { return default(Matrix4x4); } set {} }
        public static Camera[] allCameras { get { return default(Camera[]); } }
        public static int allCamerasCount { get { return default(int); } }
        public static Camera current { get { return default(Camera); } }
        public static Camera main { get { return default(Camera); } }
         
         
        public extern Matrix4x4 CalculateObliqueMatrix(Vector4 clipPlane);
        public extern void CopyFrom(Camera other);
        public extern void Render();
        public extern void RenderDontRestore();
        public extern bool RenderToCubemap(Cubemap cubemap);
        public extern bool RenderToCubemap(Cubemap cubemap, int faceMask);
        public extern bool RenderToCubemap(RenderTexture cubemap);
        public extern bool RenderToCubemap(RenderTexture cubemap, int faceMask);
        public extern void RenderWithShader(Shader shader, string replacementTag);
        public extern void ResetAspect();
        public extern void ResetProjectionMatrix();
        public extern void ResetReplacementShader();
        public extern void ResetWorldToCameraMatrix();
        public extern Ray ScreenPointToRay(Vector3 position);
        public extern Vector3 ScreenToViewportPoint(Vector3 position);
        public extern Vector3 ScreenToWorldPoint(Vector3 position);
        public extern void SetReplacementShader(Shader shader, string replacementTag);
        public extern void SetTargetBuffers(RenderBuffer colorBuffer, RenderBuffer depthBuffer);
        public extern void SetTargetBuffers(RenderBuffer[] colorBuffer, RenderBuffer depthBuffer);
        public extern Ray ViewportPointToRay(Vector3 position);
        public extern Vector3 ViewportToScreenPoint(Vector3 position);
        public extern Vector3 ViewportToWorldPoint(Vector3 position);
        public extern Vector3 WorldToScreenPoint(Vector3 position);
        public extern Vector3 WorldToViewportPoint(Vector3 position);
        public static extern int GetAllCameras(Camera[] cameras);
        public static extern void SetupCurrent(Camera cur);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Animator : Behaviour
    {
        public extern Animator();
         
        public bool applyRootMotion { get { return default(bool); } set {} }
        public Avatar avatar { get { return default(Avatar); } set {} }
        public Vector3 bodyPosition { get { return default(Vector3); } set {} }
        public Quaternion bodyRotation { get { return default(Quaternion); } set {} }
        public AnimatorCullingMode cullingMode { get { return default(AnimatorCullingMode); } set {} }
        public Vector3 deltaPosition { get { return default(Vector3); } }
        public Quaternion deltaRotation { get { return default(Quaternion); } }
        public float feetPivotActive { get { return default(float); } set {} }
        public bool fireEvents { get { return default(bool); } set {} }
        public float gravityWeight { get { return default(float); } }
        public bool hasRootMotion { get { return default(bool); } }
        public bool hasTransformHierarchy { get { return default(bool); } }
        public float humanScale { get { return default(float); } }
        public bool isHuman { get { return default(bool); } }
        public bool isMatchingTarget { get { return default(bool); } }
        public bool isOptimizable { get { return default(bool); } }
        public int layerCount { get { return default(int); } }
        public bool layersAffectMassCenter { get { return default(bool); } set {} }
        public float leftFeetBottomHeight { get { return default(float); } }
        public bool logWarnings { get { return default(bool); } set {} }
        public Vector3 pivotPosition { get { return default(Vector3); } }
        public float pivotWeight { get { return default(float); } }
        public float playbackTime { get { return default(float); } set {} }
        public float recorderStartTime { get { return default(float); } set {} }
        public float recorderStopTime { get { return default(float); } set {} }
        public float rightFeetBottomHeight { get { return default(float); } }
        public Vector3 rootPosition { get { return default(Vector3); } set {} }
        public Quaternion rootRotation { get { return default(Quaternion); } set {} }
        public RuntimeAnimatorController runtimeAnimatorController { get { return default(RuntimeAnimatorController); } set {} }
        public float speed { get { return default(float); } set {} }
        public bool stabilizeFeet { get { return default(bool); } set {} }
        public Vector3 targetPosition { get { return default(Vector3); } }
        public Quaternion targetRotation { get { return default(Quaternion); } }
        public AnimatorUpdateMode updateMode { get { return default(AnimatorUpdateMode); } set {} }
         
         
        public extern void CrossFade(int stateNameHash, float transitionDuration);
        public extern void CrossFade(int stateNameHash, float transitionDuration, int layer);
        public extern void CrossFade(int stateNameHash, float transitionDuration, int layer, float normalizedTime);
        public extern void CrossFade(string stateName, float transitionDuration);
        public extern void CrossFade(string stateName, float transitionDuration, int layer);
        public extern void CrossFade(string stateName, float transitionDuration, int layer, float normalizedTime);
        public extern AnimatorTransitionInfo GetAnimatorTransitionInfo(int layerIndex);
        public extern Transform GetBoneTransform(HumanBodyBones humanBoneId);
        public extern bool GetBool(int id);
        public extern bool GetBool(string name);
        public extern AnimationInfo[] GetCurrentAnimationClipState(int layerIndex);
        public extern AnimatorStateInfo GetCurrentAnimatorStateInfo(int layerIndex);
        public extern float GetFloat(int id);
        public extern float GetFloat(string name);
        public extern Vector3 GetIKPosition(AvatarIKGoal goal);
        public extern float GetIKPositionWeight(AvatarIKGoal goal);
        public extern Quaternion GetIKRotation(AvatarIKGoal goal);
        public extern float GetIKRotationWeight(AvatarIKGoal goal);
        public extern int GetInteger(int id);
        public extern int GetInteger(string name);
        public extern string GetLayerName(int layerIndex);
        public extern float GetLayerWeight(int layerIndex);
        public extern AnimationInfo[] GetNextAnimationClipState(int layerIndex);
        public extern AnimatorStateInfo GetNextAnimatorStateInfo(int layerIndex);
        public extern void InterruptMatchTarget();
        public extern void InterruptMatchTarget(bool completeMatch);
        public extern bool IsInTransition(int layerIndex);
        public extern bool IsParameterControlledByCurve(int id);
        public extern bool IsParameterControlledByCurve(string name);
        public extern void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime);
        public extern void MatchTarget(Vector3 matchPosition, Quaternion matchRotation, AvatarTarget targetBodyPart, MatchTargetWeightMask weightMask, float startNormalizedTime, float targetNormalizedTime);
        public extern void Play(int stateNameHash);
        public extern void Play(int stateNameHash, int layer);
        public extern void Play(int stateNameHash, int layer, float normalizedTime);
        public extern void Play(string stateName);
        public extern void Play(string stateName, int layer);
        public extern void Play(string stateName, int layer, float normalizedTime);
        public extern void Rebind();
        public extern void ResetTrigger(int id);
        public extern void ResetTrigger(string name);
        public extern void SetBool(int id, bool value);
        public extern void SetBool(string name, bool value);
        public extern void SetFloat(int id, float value);
        public extern void SetFloat(int id, float value, float dampTime, float deltaTime);
        public extern void SetFloat(string name, float value);
        public extern void SetFloat(string name, float value, float dampTime, float deltaTime);
        public extern void SetIKPosition(AvatarIKGoal goal, Vector3 goalPosition);
        public extern void SetIKPositionWeight(AvatarIKGoal goal, float value);
        public extern void SetIKRotation(AvatarIKGoal goal, Quaternion goalRotation);
        public extern void SetIKRotationWeight(AvatarIKGoal goal, float value);
        public extern void SetInteger(int id, int value);
        public extern void SetInteger(string name, int value);
        public extern void SetLayerWeight(int layerIndex, float weight);
        public extern void SetLookAtPosition(Vector3 lookAtPosition);
        public extern void SetLookAtWeight(float weight);
        public extern void SetLookAtWeight(float weight, float bodyWeight);
        public extern void SetLookAtWeight(float weight, float bodyWeight, float headWeight);
        public extern void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight);
        public extern void SetLookAtWeight(float weight, float bodyWeight, float headWeight, float eyesWeight, float clampWeight);
        public extern void SetTarget(AvatarTarget targetIndex, float targetNormalizedTime);
        public extern void SetTrigger(int id);
        public extern void SetTrigger(string name);
        public extern void StartPlayback();
        public extern void StartRecording(int frameCount);
        public extern void StopPlayback();
        public extern void StopRecording();
        public extern void Update(float deltaTime);
        public static extern int StringToHash(string name);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class RectTransform : Transform
    {
            [Bridge.FileName("csw")]
            public enum Edge
            {
                Left = 0,
                Right = 1,
                Top = 2,
                Bottom = 3,
            }
            [Bridge.FileName("csw")]
            public enum Axis
            {
                Horizontal = 0,
                Vertical = 1,
            }
        public extern RectTransform();
         
        public Vector2 anchoredPosition { get { return default(Vector2); } set {} }
        public Vector3 anchoredPosition3D { get { return default(Vector3); } set {} }
        public Vector2 anchorMax { get { return default(Vector2); } set {} }
        public Vector2 anchorMin { get { return default(Vector2); } set {} }
        public Vector2 offsetMax { get { return default(Vector2); } set {} }
        public Vector2 offsetMin { get { return default(Vector2); } set {} }
        public Vector2 pivot { get { return default(Vector2); } set {} }
        public Rect rect { get { return default(Rect); } }
        public Vector2 sizeDelta { get { return default(Vector2); } set {} }
         
         
        public extern void GetLocalCorners(Vector3[] fourCornersArray);
        public extern void GetWorldCorners(Vector3[] fourCornersArray);
        public extern void SetInsetAndSizeFromParentEdge(RectTransform.Edge edge, float inset, float size);
        public extern void SetSizeWithCurrentAnchors(RectTransform.Axis axis, float size);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class MeshCollider : Collider
    {
        public extern MeshCollider();
         
        public bool convex { get { return default(bool); } set {} }
        public Mesh sharedMesh { get { return default(Mesh); } set {} }
        public bool smoothSphereCollisions { get { return default(bool); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Animation : Behaviour, System.Collections.IEnumerable
    {
        public extern Animation();
         
        public bool animatePhysics { get { return default(bool); } set {} }
        public AnimationClip clip { get { return default(AnimationClip); } set {} }
        public AnimationCullingType cullingType { get { return default(AnimationCullingType); } set {} }
        public bool isPlaying { get { return default(bool); } }
        public Bounds localBounds { get { return default(Bounds); } set {} }
        public bool playAutomatically { get { return default(bool); } set {} }
        public WrapMode wrapMode { get { return default(WrapMode); } set {} }
         
        public AnimationState this[string name] { get { return default(AnimationState); } }
         
        public extern void AddClip(AnimationClip clip, string newName);
        public extern void AddClip(AnimationClip clip, string newName, int firstFrame, int lastFrame);
        public extern void AddClip(AnimationClip clip, string newName, int firstFrame, int lastFrame, bool addLoopFrame);
        public extern void Blend(string animation);
        public extern void Blend(string animation, float targetWeight);
        public extern void Blend(string animation, float targetWeight, float fadeLength);
        public extern void CrossFade(string animation);
        public extern void CrossFade(string animation, float fadeLength);
        public extern void CrossFade(string animation, float fadeLength, PlayMode mode);
        public extern AnimationState CrossFadeQueued(string animation);
        public extern AnimationState CrossFadeQueued(string animation, float fadeLength);
        public extern AnimationState CrossFadeQueued(string animation, float fadeLength, QueueMode queue);
        public extern AnimationState CrossFadeQueued(string animation, float fadeLength, QueueMode queue, PlayMode mode);
        public extern AnimationClip GetClip(string name);
        public extern int GetClipCount();
        public extern virtual System.Collections.IEnumerator GetEnumerator();
        public extern bool IsPlaying(string name);
        public extern bool Play();
        public extern bool Play(string animation);
        public extern bool Play(string animation, PlayMode mode);
        public extern bool Play(PlayMode mode);
        public extern AnimationState PlayQueued(string animation);
        public extern AnimationState PlayQueued(string animation, QueueMode queue);
        public extern AnimationState PlayQueued(string animation, QueueMode queue, PlayMode mode);
        public extern void RemoveClip(string clipName);
        public extern void RemoveClip(AnimationClip clip);
        public extern void Rewind();
        public extern void Rewind(string name);
        public extern void Sample();
        public extern void Stop();
        public extern void Stop(string name);
        public extern void SyncLayer(int layer);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class MeshRenderer : Renderer
    {
        public extern MeshRenderer();
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class SphereCollider : Collider
    {
        public extern SphereCollider();
         
        public Vector3 center { get { return default(Vector3); } set {} }
        public float radius { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class LineRenderer : Renderer
    {
        public extern LineRenderer();
         
        public bool useWorldSpace { get { return default(bool); } set {} }
         
         
        public extern void SetColors(Color start, Color end);
        public extern void SetPosition(int index, Vector3 position);
        public extern void SetVertexCount(int count);
        public extern void SetWidth(float start, float end);
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public class UIBehaviour : UnityEngine.MonoBehaviour
    {
        public extern virtual bool IsActive();
        public extern bool IsDestroyed();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class GUIText : GUIElement
    {
        public extern GUIText();
         
        public TextAlignment alignment { get { return default(TextAlignment); } set {} }
        public TextAnchor anchor { get { return default(TextAnchor); } set {} }
        public Color color { get { return default(Color); } set {} }
        public Font font { get { return default(Font); } set {} }
        public int fontSize { get { return default(int); } set {} }
        public FontStyle fontStyle { get { return default(FontStyle); } set {} }
        public float lineSpacing { get { return default(float); } set {} }
        public Material material { get { return default(Material); } set {} }
        public Vector2 pixelOffset { get { return default(Vector2); } set {} }
        public bool richText { get { return default(bool); } set {} }
        public float tabSize { get { return default(float); } set {} }
        public string text { get { return default(string); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class GUITexture : GUIElement
    {
        public extern GUITexture();
         
        public RectOffset border { get { return default(RectOffset); } set {} }
        public Color color { get { return default(Color); } set {} }
        public Rect pixelInset { get { return default(Rect); } set {} }
        public Texture texture { get { return default(Texture); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class BoxCollider2D : Collider2D
    {
        public extern BoxCollider2D();
         
        public Vector2 center { get { return default(Vector2); } set {} }
        public Vector2 size { get { return default(Vector2); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class PolygonCollider2D : Collider2D
    {
        public extern PolygonCollider2D();
         
        public int pathCount { get { return default(int); } set {} }
        public Vector2[] points { get { return default(Vector2[]); } set {} }
         
         
        public extern void CreatePrimitive(int sides);
        public extern void CreatePrimitive(int sides, Vector2 scale);
        public extern void CreatePrimitive(int sides, Vector2 scale, Vector2 offset);
        public extern Vector2[] GetPath(int index);
        public extern int GetTotalPointCount();
        public extern void SetPath(int index, Vector2[] points);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class CircleCollider2D : Collider2D
    {
        public extern CircleCollider2D();
         
        public Vector2 center { get { return default(Vector2); } set {} }
        public float radius { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class LayoutGroup : UnityEngine.EventSystems.UIBehaviour, ILayoutElement, ILayoutController, ILayoutGroup
    {
        public UnityEngine.TextAnchor childAlignment { get { return default(UnityEngine.TextAnchor); } set {} }
        public virtual float flexibleHeight { get { return default(float); } }
        public virtual float flexibleWidth { get { return default(float); } }
        public virtual int layoutPriority { get { return default(int); } }
        public virtual float minHeight { get { return default(float); } }
        public virtual float minWidth { get { return default(float); } }
        public UnityEngine.RectOffset padding { get { return default(UnityEngine.RectOffset); } set {} }
        public virtual float preferredHeight { get { return default(float); } }
        public virtual float preferredWidth { get { return default(float); } }
         
         
        public extern virtual void CalculateLayoutInputHorizontal();
        public extern virtual void CalculateLayoutInputVertical();
        public extern virtual void SetLayoutHorizontal();
        public extern virtual void SetLayoutVertical();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class Graphic : UnityEngine.EventSystems.UIBehaviour, ICanvasElement
    {
        public UnityEngine.Canvas canvas { get { return default(UnityEngine.Canvas); } }
        public UnityEngine.CanvasRenderer canvasRenderer { get { return default(UnityEngine.CanvasRenderer); } }
        public UnityEngine.Color color { get { return default(UnityEngine.Color); } set {} }
        public virtual UnityEngine.Material defaultMaterial { get { return default(UnityEngine.Material); } }
        public int depth { get { return default(int); } }
        public virtual UnityEngine.Texture mainTexture { get { return default(UnityEngine.Texture); } }
        public virtual UnityEngine.Material material { get { return default(UnityEngine.Material); } set {} }
        public virtual UnityEngine.Material materialForRendering { get { return default(UnityEngine.Material); } }
        public UnityEngine.RectTransform rectTransform { get { return default(UnityEngine.RectTransform); } }
        public static UnityEngine.Material defaultGraphicMaterial { get { return default(UnityEngine.Material); } }
         
         
        public extern void CrossFadeAlpha(float alpha, float duration, bool ignoreTimeScale);
        public extern void CrossFadeColor(UnityEngine.Color targetColor, float duration, bool ignoreTimeScale, bool useAlpha);
        public extern UnityEngine.Rect GetPixelAdjustedRect();
        public extern UnityEngine.Vector2 PixelAdjustPoint(UnityEngine.Vector2 point);
        public extern virtual bool Raycast(UnityEngine.Vector2 sp, UnityEngine.Camera eventCamera);
        public extern virtual void Rebuild(CanvasUpdate update);
        public extern void RegisterDirtyLayoutCallback(UnityEngine.Events.UnityAction action);
        public extern void RegisterDirtyMaterialCallback(UnityEngine.Events.UnityAction action);
        public extern void RegisterDirtyVerticesCallback(UnityEngine.Events.UnityAction action);
        public extern virtual void SetAllDirty();
        public extern virtual void SetLayoutDirty();
        public extern virtual void SetMaterialDirty();
        public extern virtual void SetNativeSize();
        public extern virtual void SetVerticesDirty();
        public extern void UnregisterDirtyLayoutCallback(UnityEngine.Events.UnityAction action);
        public extern void UnregisterDirtyMaterialCallback(UnityEngine.Events.UnityAction action);
        public extern void UnregisterDirtyVerticesCallback(UnityEngine.Events.UnityAction action);
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class Selectable : UnityEngine.EventSystems.UIBehaviour, UnityEngine.EventSystems.IEventSystemHandler, UnityEngine.EventSystems.IPointerEnterHandler, UnityEngine.EventSystems.IPointerExitHandler, UnityEngine.EventSystems.IPointerDownHandler, UnityEngine.EventSystems.IPointerUpHandler, UnityEngine.EventSystems.ISelectHandler, UnityEngine.EventSystems.IDeselectHandler, UnityEngine.EventSystems.IMoveHandler
    {
            [Bridge.FileName("csw")]
            public enum Transition
            {
                None = 0,
                ColorTint = 1,
                SpriteSwap = 2,
                Animation = 3,
            }
        public AnimationTriggers animationTriggers { get { return default(AnimationTriggers); } set {} }
        public UnityEngine.Animator animator { get { return default(UnityEngine.Animator); } }
        public ColorBlock colors { get { return default(ColorBlock); } set {} }
        public Image image { get { return default(Image); } set {} }
        public bool interactable { get { return default(bool); } set {} }
        public Navigation navigation { get { return default(Navigation); } set {} }
        public SpriteState spriteState { get { return default(SpriteState); } set {} }
        public Graphic targetGraphic { get { return default(Graphic); } set {} }
        public Selectable.Transition transition { get { return default(Selectable.Transition); } set {} }
        public static System.Collections.Generic.List<UnityEngine.UI.Selectable> allSelectables { get { return default(System.Collections.Generic.List<UnityEngine.UI.Selectable>); } }
         
         
        public extern Selectable FindSelectable(UnityEngine.Vector3 dir);
        public extern virtual Selectable FindSelectableOnDown();
        public extern virtual Selectable FindSelectableOnLeft();
        public extern virtual Selectable FindSelectableOnRight();
        public extern virtual Selectable FindSelectableOnUp();
        public extern virtual bool IsInteractable();
        public extern virtual void OnDeselect(UnityEngine.EventSystems.BaseEventData eventData);
        public extern virtual void OnMove(UnityEngine.EventSystems.AxisEventData eventData);
        public extern virtual void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData);
        public extern virtual void OnPointerEnter(UnityEngine.EventSystems.PointerEventData eventData);
        public extern virtual void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData);
        public extern virtual void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData);
        public extern virtual void OnSelect(UnityEngine.EventSystems.BaseEventData eventData);
        public extern virtual void Select();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class GridLayoutGroup : LayoutGroup
    {
            [Bridge.FileName("csw")]
            public enum Constraint
            {
                Flexible = 0,
                FixedColumnCount = 1,
                FixedRowCount = 2,
            }
            [Bridge.FileName("csw")]
            public enum Axis
            {
                Horizontal = 0,
                Vertical = 1,
            }
            [Bridge.FileName("csw")]
            public enum Corner
            {
                UpperLeft = 0,
                UpperRight = 1,
                LowerLeft = 2,
                LowerRight = 3,
            }
        public UnityEngine.Vector2 cellSize { get { return default(UnityEngine.Vector2); } set {} }
        public GridLayoutGroup.Constraint constraint { get { return default(GridLayoutGroup.Constraint); } set {} }
        public int constraintCount { get { return default(int); } set {} }
        public UnityEngine.Vector2 spacing { get { return default(UnityEngine.Vector2); } set {} }
        public GridLayoutGroup.Axis startAxis { get { return default(GridLayoutGroup.Axis); } set {} }
        public GridLayoutGroup.Corner startCorner { get { return default(GridLayoutGroup.Corner); } set {} }
         
         
        public extern override void CalculateLayoutInputHorizontal();
        public extern override void CalculateLayoutInputVertical();
        public extern override void SetLayoutHorizontal();
        public extern override void SetLayoutVertical();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class MaskableGraphic : Graphic, IMaskable
    {
        public bool maskable { get { return default(bool); } set {} }
        public override UnityEngine.Material material { get { return default(UnityEngine.Material); } set {} }
         
         
        public extern virtual void ParentMaskStateChanged();
        public extern override void SetMaterialDirty();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class Button : Selectable, UnityEngine.EventSystems.IPointerClickHandler, UnityEngine.EventSystems.ISubmitHandler
    {
            [Bridge.FileName("csw")]
            public class ButtonClickedEvent : UnityEngine.Events.UnityEvent
            {
                public extern ButtonClickedEvent();
                 
            }
        public Button.ButtonClickedEvent onClick { get { return default(Button.ButtonClickedEvent); } set {} }
         
         
        public extern virtual void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData);
        public extern virtual void OnSubmit(UnityEngine.EventSystems.BaseEventData eventData);
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class Text : MaskableGraphic, ILayoutElement
    {
        public UnityEngine.TextAnchor alignment { get { return default(UnityEngine.TextAnchor); } set {} }
        public UnityEngine.TextGenerator cachedTextGenerator { get { return default(UnityEngine.TextGenerator); } }
        public UnityEngine.TextGenerator cachedTextGeneratorForLayout { get { return default(UnityEngine.TextGenerator); } }
        public override UnityEngine.Material defaultMaterial { get { return default(UnityEngine.Material); } }
        public virtual float flexibleHeight { get { return default(float); } }
        public virtual float flexibleWidth { get { return default(float); } }
        public UnityEngine.Font font { get { return default(UnityEngine.Font); } set {} }
        public int fontSize { get { return default(int); } set {} }
        public UnityEngine.FontStyle fontStyle { get { return default(UnityEngine.FontStyle); } set {} }
        public UnityEngine.HorizontalWrapMode horizontalOverflow { get { return default(UnityEngine.HorizontalWrapMode); } set {} }
        public virtual int layoutPriority { get { return default(int); } }
        public float lineSpacing { get { return default(float); } set {} }
        public override UnityEngine.Texture mainTexture { get { return default(UnityEngine.Texture); } }
        public virtual float minHeight { get { return default(float); } }
        public virtual float minWidth { get { return default(float); } }
        public float pixelsPerUnit { get { return default(float); } }
        public virtual float preferredHeight { get { return default(float); } }
        public virtual float preferredWidth { get { return default(float); } }
        public bool resizeTextForBestFit { get { return default(bool); } set {} }
        public int resizeTextMaxSize { get { return default(int); } set {} }
        public int resizeTextMinSize { get { return default(int); } set {} }
        public bool supportRichText { get { return default(bool); } set {} }
        public virtual string text { get { return default(string); } set {} }
        public UnityEngine.VerticalWrapMode verticalOverflow { get { return default(UnityEngine.VerticalWrapMode); } set {} }
         
         
        public extern virtual void CalculateLayoutInputHorizontal();
        public extern virtual void CalculateLayoutInputVertical();
        public extern void FontTextureChanged();
        public extern UnityEngine.TextGenerationSettings GetGenerationSettings(UnityEngine.Vector2 extents);
        public static extern UnityEngine.Vector2 GetTextAnchorPivot(UnityEngine.TextAnchor anchor);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Vector4
    {
        public static float kEpsilon;
        public float x;
        public float y;
        public float z;
        public float w;
         
        public extern Vector4(float x, float y);
        public extern Vector4(float x, float y, float z);
        public extern Vector4(float x, float y, float z, float w);
         
        public float magnitude { get { return default(float); } }
        public Vector4 normalized { get { return default(Vector4); } }
        public float sqrMagnitude { get { return default(float); } }
        public static Vector4 one { get { return default(Vector4); } }
        public static Vector4 zero { get { return default(Vector4); } }
         
        public float this[int index] { get { return default(float); } set {} }
         
        public static extern Vector4 operator +(Vector4 a, Vector4 b);
        public static extern Vector4 operator /(Vector4 a, float d);
        public static extern bool operator ==(Vector4 lhs, Vector4 rhs);
        public static extern implicit operator Vector2(Vector4 v);
        public static extern implicit operator Vector3(Vector4 v);
        public static extern implicit operator Vector4(Vector2 v);
        public static extern implicit operator Vector4(Vector3 v);
        public static extern bool operator !=(Vector4 lhs, Vector4 rhs);
        public static extern Vector4 operator *(float d, Vector4 a);
        public static extern Vector4 operator *(Vector4 a, float d);
        public static extern Vector4 operator -(Vector4 a, Vector4 b);
        public static extern Vector4 operator -(Vector4 a);
         
        public extern override bool Equals(object other);
        public extern override int GetHashCode();
        public extern void Normalize();
        public extern void Scale(Vector4 scale);
        public extern void Set(float new_x, float new_y, float new_z, float new_w);
        public extern float SqrMagnitude();
        public extern override string ToString();
        public extern string ToString(string format);
        public static extern float Distance(Vector4 a, Vector4 b);
        public static extern float Dot(Vector4 a, Vector4 b);
        public static extern Vector4 Lerp(Vector4 from, Vector4 to, float t);
        public static extern float Magnitude(Vector4 a);
        public static extern Vector4 Max(Vector4 lhs, Vector4 rhs);
        public static extern Vector4 Min(Vector4 lhs, Vector4 rhs);
        public static extern Vector4 MoveTowards(Vector4 current, Vector4 target, float maxDistanceDelta);
        public static extern Vector4 Normalize(Vector4 a);
        public static extern Vector4 Project(Vector4 a, Vector4 b);
        public static extern Vector4 Scale(Vector4 a, Vector4 b);
        public static extern float SqrMagnitude(Vector4 a);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Ray
    {
        public extern Ray(Vector3 origin, Vector3 direction);
         
        public Vector3 direction { get { return default(Vector3); } set {} }
        public Vector3 origin { get { return default(Vector3); } set {} }
         
         
        public extern Vector3 GetPoint(float distance);
        public extern override string ToString();
        public extern string ToString(string format);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Resolution
    {
         
        public int height { get { return default(int); } set {} }
        public int refreshRate { get { return default(int); } set {} }
        public int width { get { return default(int); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum ScreenOrientation
    {
        Unknown = 0,
        Portrait = 1,
        PortraitUpsideDown = 2,
        LandscapeLeft = 3,
        LandscapeRight = 4,
        AutoRotation = 5,
        Landscape = 3,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct ContactPoint2D
    {
         
        public Collider2D collider { get { return default(Collider2D); } }
        public Vector2 normal { get { return default(Vector2); } }
        public Collider2D otherCollider { get { return default(Collider2D); } }
        public Vector2 point { get { return default(Vector2); } }
         
         
    }
}
 
namespace System.Collections
{
    [Bridge.FileName("csw")]
    public interface IDictionaryEnumerator : IEnumerator
    {
        DictionaryEntry Entry { get; }
        object Key { get; }
        object Value { get; }
         
         
    }
}
 
namespace System.Runtime.Serialization
{
    [Bridge.FileName("csw")]
    public class SerializationInfo
    {
        public extern SerializationInfo(System.Type type, IFormatterConverter converter);
         
        public string AssemblyName { get { return default(string); } set {} }
        public string FullTypeName { get { return default(string); } set {} }
        public int MemberCount { get { return default(int); } }
         
         
        public extern void AddValue(string name, bool value);
        public extern void AddValue(string name, byte value);
        public extern void AddValue(string name, System.Char value);
        public extern void AddValue(string name, System.DateTime value);
        public extern void AddValue(string name, System.Decimal value);
        public extern void AddValue(string name, double value);
        public extern void AddValue(string name, short value);
        public extern void AddValue(string name, int value);
        public extern void AddValue(string name, long value);
        public extern void AddValue(string name, object value);
        public extern void AddValue(string name, object value, System.Type type);
        public extern void AddValue(string name, sbyte value);
        public extern void AddValue(string name, float value);
        public extern void AddValue(string name, ushort value);
        public extern void AddValue(string name, uint value);
        public extern void AddValue(string name, ulong value);
        public extern bool GetBoolean(string name);
        public extern byte GetByte(string name);
        public extern System.Char GetChar(string name);
        public extern System.DateTime GetDateTime(string name);
        public extern System.Decimal GetDecimal(string name);
        public extern double GetDouble(string name);
        public extern SerializationInfoEnumerator GetEnumerator();
        public extern short GetInt16(string name);
        public extern int GetInt32(string name);
        public extern long GetInt64(string name);
        public extern sbyte GetSByte(string name);
        public extern float GetSingle(string name);
        public extern string GetString(string name);
        public extern ushort GetUInt16(string name);
        public extern uint GetUInt32(string name);
        public extern ulong GetUInt64(string name);
        public extern object GetValue(string name, System.Type type);
        public extern void SetType(System.Type type);
    }
}
 
namespace System.Runtime.Serialization
{
    [Bridge.FileName("csw")]
    public struct StreamingContext
    {
        public extern StreamingContext(StreamingContextStates state);
        public extern StreamingContext(StreamingContextStates state, object additional);
         
        public object Context { get { return default(object); } }
        public StreamingContextStates State { get { return default(StreamingContextStates); } }
         
         
        public extern override bool Equals(object obj);
        public extern override int GetHashCode();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public enum CanvasUpdate
    {
        Prelayout = 0,
        Layout = 1,
        PostLayout = 2,
        PreRender = 3,
        LatePreRender = 4,
        MaxUpdateValue = 5,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum NavMeshPathStatus
    {
        PathComplete = 0,
        PathPartial = 1,
        PathInvalid = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct AccelerationEvent
    {
         
        public Vector3 acceleration { get { return default(Vector3); } }
        public float deltaTime { get { return default(float); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Compass
    {
        public extern Compass();
         
        public bool enabled { get { return default(bool); } set {} }
        public float headingAccuracy { get { return default(float); } }
        public float magneticHeading { get { return default(float); } }
        public Vector3 rawVector { get { return default(Vector3); } }
        public double timestamp { get { return default(double); } }
        public float trueHeading { get { return default(float); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum DeviceOrientation
    {
        Unknown = 0,
        Portrait = 1,
        PortraitUpsideDown = 2,
        LandscapeLeft = 3,
        LandscapeRight = 4,
        FaceUp = 5,
        FaceDown = 6,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Gyroscope
    {
        public Quaternion attitude { get { return default(Quaternion); } }
        public bool enabled { get { return default(bool); } set {} }
        public Vector3 gravity { get { return default(Vector3); } }
        public Vector3 rotationRate { get { return default(Vector3); } }
        public Vector3 rotationRateUnbiased { get { return default(Vector3); } }
        public float updateInterval { get { return default(float); } set {} }
        public Vector3 userAcceleration { get { return default(Vector3); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum IMECompositionMode
    {
        Auto = 0,
        On = 1,
        Off = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class LocationService
    {
        public extern LocationService();
         
        public bool isEnabledByUser { get { return default(bool); } }
        public LocationInfo lastData { get { return default(LocationInfo); } }
        public LocationServiceStatus status { get { return default(LocationServiceStatus); } }
         
         
        public extern void Start();
        public extern void Start(float desiredAccuracyInMeters);
        public extern void Start(float desiredAccuracyInMeters, float updateDistanceInMeters);
        public extern void Stop();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Touch
    {
         
        public Vector2 deltaPosition { get { return default(Vector2); } }
        public float deltaTime { get { return default(float); } }
        public int fingerId { get { return default(int); } }
        public TouchPhase phase { get { return default(TouchPhase); } }
        public Vector2 position { get { return default(Vector2); } }
        public Vector2 rawPosition { get { return default(Vector2); } }
        public int tapCount { get { return default(int); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum KeyCode
    {
        None = 0,
        Backspace = 8,
        Delete = 127,
        Tab = 9,
        Clear = 12,
        Return = 13,
        Pause = 19,
        Escape = 27,
        Space = 32,
        Keypad0 = 256,
        Keypad1 = 257,
        Keypad2 = 258,
        Keypad3 = 259,
        Keypad4 = 260,
        Keypad5 = 261,
        Keypad6 = 262,
        Keypad7 = 263,
        Keypad8 = 264,
        Keypad9 = 265,
        KeypadPeriod = 266,
        KeypadDivide = 267,
        KeypadMultiply = 268,
        KeypadMinus = 269,
        KeypadPlus = 270,
        KeypadEnter = 271,
        KeypadEquals = 272,
        UpArrow = 273,
        DownArrow = 274,
        RightArrow = 275,
        LeftArrow = 276,
        Insert = 277,
        Home = 278,
        End = 279,
        PageUp = 280,
        PageDown = 281,
        F1 = 282,
        F2 = 283,
        F3 = 284,
        F4 = 285,
        F5 = 286,
        F6 = 287,
        F7 = 288,
        F8 = 289,
        F9 = 290,
        F10 = 291,
        F11 = 292,
        F12 = 293,
        F13 = 294,
        F14 = 295,
        F15 = 296,
        Alpha0 = 48,
        Alpha1 = 49,
        Alpha2 = 50,
        Alpha3 = 51,
        Alpha4 = 52,
        Alpha5 = 53,
        Alpha6 = 54,
        Alpha7 = 55,
        Alpha8 = 56,
        Alpha9 = 57,
        Exclaim = 33,
        DoubleQuote = 34,
        Hash = 35,
        Dollar = 36,
        Ampersand = 38,
        Quote = 39,
        LeftParen = 40,
        RightParen = 41,
        Asterisk = 42,
        Plus = 43,
        Comma = 44,
        Minus = 45,
        Period = 46,
        Slash = 47,
        Colon = 58,
        Semicolon = 59,
        Less = 60,
        Equals = 61,
        Greater = 62,
        Question = 63,
        At = 64,
        LeftBracket = 91,
        Backslash = 92,
        RightBracket = 93,
        Caret = 94,
        Underscore = 95,
        BackQuote = 96,
        A = 97,
        B = 98,
        C = 99,
        D = 100,
        E = 101,
        F = 102,
        G = 103,
        H = 104,
        I = 105,
        J = 106,
        K = 107,
        L = 108,
        M = 109,
        N = 110,
        O = 111,
        P = 112,
        Q = 113,
        R = 114,
        S = 115,
        T = 116,
        U = 117,
        V = 118,
        W = 119,
        X = 120,
        Y = 121,
        Z = 122,
        Numlock = 300,
        CapsLock = 301,
        ScrollLock = 302,
        RightShift = 303,
        LeftShift = 304,
        RightControl = 305,
        LeftControl = 306,
        RightAlt = 307,
        LeftAlt = 308,
        LeftCommand = 310,
        LeftApple = 310,
        LeftWindows = 311,
        RightCommand = 309,
        RightApple = 309,
        RightWindows = 312,
        AltGr = 313,
        Help = 315,
        Print = 316,
        SysReq = 317,
        Break = 318,
        Menu = 319,
        Mouse0 = 323,
        Mouse1 = 324,
        Mouse2 = 325,
        Mouse3 = 326,
        Mouse4 = 327,
        Mouse5 = 328,
        Mouse6 = 329,
        JoystickButton0 = 330,
        JoystickButton1 = 331,
        JoystickButton2 = 332,
        JoystickButton3 = 333,
        JoystickButton4 = 334,
        JoystickButton5 = 335,
        JoystickButton6 = 336,
        JoystickButton7 = 337,
        JoystickButton8 = 338,
        JoystickButton9 = 339,
        JoystickButton10 = 340,
        JoystickButton11 = 341,
        JoystickButton12 = 342,
        JoystickButton13 = 343,
        JoystickButton14 = 344,
        JoystickButton15 = 345,
        JoystickButton16 = 346,
        JoystickButton17 = 347,
        JoystickButton18 = 348,
        JoystickButton19 = 349,
        Joystick1Button0 = 350,
        Joystick1Button1 = 351,
        Joystick1Button2 = 352,
        Joystick1Button3 = 353,
        Joystick1Button4 = 354,
        Joystick1Button5 = 355,
        Joystick1Button6 = 356,
        Joystick1Button7 = 357,
        Joystick1Button8 = 358,
        Joystick1Button9 = 359,
        Joystick1Button10 = 360,
        Joystick1Button11 = 361,
        Joystick1Button12 = 362,
        Joystick1Button13 = 363,
        Joystick1Button14 = 364,
        Joystick1Button15 = 365,
        Joystick1Button16 = 366,
        Joystick1Button17 = 367,
        Joystick1Button18 = 368,
        Joystick1Button19 = 369,
        Joystick2Button0 = 370,
        Joystick2Button1 = 371,
        Joystick2Button2 = 372,
        Joystick2Button3 = 373,
        Joystick2Button4 = 374,
        Joystick2Button5 = 375,
        Joystick2Button6 = 376,
        Joystick2Button7 = 377,
        Joystick2Button8 = 378,
        Joystick2Button9 = 379,
        Joystick2Button10 = 380,
        Joystick2Button11 = 381,
        Joystick2Button12 = 382,
        Joystick2Button13 = 383,
        Joystick2Button14 = 384,
        Joystick2Button15 = 385,
        Joystick2Button16 = 386,
        Joystick2Button17 = 387,
        Joystick2Button18 = 388,
        Joystick2Button19 = 389,
        Joystick3Button0 = 390,
        Joystick3Button1 = 391,
        Joystick3Button2 = 392,
        Joystick3Button3 = 393,
        Joystick3Button4 = 394,
        Joystick3Button5 = 395,
        Joystick3Button6 = 396,
        Joystick3Button7 = 397,
        Joystick3Button8 = 398,
        Joystick3Button9 = 399,
        Joystick3Button10 = 400,
        Joystick3Button11 = 401,
        Joystick3Button12 = 402,
        Joystick3Button13 = 403,
        Joystick3Button14 = 404,
        Joystick3Button15 = 405,
        Joystick3Button16 = 406,
        Joystick3Button17 = 407,
        Joystick3Button18 = 408,
        Joystick3Button19 = 409,
        Joystick4Button0 = 410,
        Joystick4Button1 = 411,
        Joystick4Button2 = 412,
        Joystick4Button3 = 413,
        Joystick4Button4 = 414,
        Joystick4Button5 = 415,
        Joystick4Button6 = 416,
        Joystick4Button7 = 417,
        Joystick4Button8 = 418,
        Joystick4Button9 = 419,
        Joystick4Button10 = 420,
        Joystick4Button11 = 421,
        Joystick4Button12 = 422,
        Joystick4Button13 = 423,
        Joystick4Button14 = 424,
        Joystick4Button15 = 425,
        Joystick4Button16 = 426,
        Joystick4Button17 = 427,
        Joystick4Button18 = 428,
        Joystick4Button19 = 429,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class WWWForm
    {
        public extern WWWForm();
         
        public byte[] data { get { return default(byte[]); } }
        public System.Collections.Hashtable headers { get { return default(System.Collections.Hashtable); } }
         
         
        public extern void AddBinaryData(string fieldName, byte[] contents);
        public extern void AddBinaryData(string fieldName, byte[] contents, string fileName);
        public extern void AddBinaryData(string fieldName, byte[] contents, string fileName, string mimeType);
        public extern void AddField(string fieldName, int i);
        public extern void AddField(string fieldName, string value);
        public extern void AddField(string fieldName, string value, System.Text.Encoding e);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AssetBundle : Object
    {
        public extern AssetBundle();
         
        public Object mainAsset { get { return default(Object); } }
         
         
        public extern bool Contains(string name);
        public extern Object Load(string name);
        public extern Object Load(string name, System.Type type);
        public extern Object[] LoadAll();
        public extern Object[] LoadAll(System.Type type);
        public extern AssetBundleRequest LoadAsync(string name, System.Type type);
        public extern void Unload(bool unloadAllLoadedObjects);
        public static extern AssetBundle CreateFromFile(string path);
        public static extern AssetBundle CreateFromFile(string path, int offset);
        public static extern AssetBundleCreateRequest CreateFromMemory(byte[] binary);
        public static extern AssetBundle CreateFromMemoryImmediate(byte[] binary);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Texture2D : Texture
    {
        public extern Texture2D(int width, int height);
        public extern Texture2D(int width, int height, TextureFormat format, bool mipmap);
        public extern Texture2D(int width, int height, TextureFormat format, bool mipmap, bool linear);
         
        public TextureFormat format { get { return default(TextureFormat); } }
        public int mipmapCount { get { return default(int); } }
        public static Texture2D blackTexture { get { return default(Texture2D); } }
        public static Texture2D whiteTexture { get { return default(Texture2D); } }
         
         
        public extern void Apply();
        public extern void Apply(bool updateMipmaps);
        public extern void Apply(bool updateMipmaps, bool makeNoLongerReadable);
        public extern void Compress(bool highQuality);
        public extern byte[] EncodeToJPG();
        public extern byte[] EncodeToJPG(int quality);
        public extern byte[] EncodeToPNG();
        public extern Color GetPixel(int x, int y);
        public extern Color GetPixelBilinear(float u, float v);
        public extern Color[] GetPixels();
        public extern Color[] GetPixels(int miplevel);
        public extern Color[] GetPixels(int x, int y, int blockWidth, int blockHeight);
        public extern Color[] GetPixels(int x, int y, int blockWidth, int blockHeight, int miplevel);
        public extern Color32[] GetPixels32();
        public extern Color32[] GetPixels32(int miplevel);
        public extern bool LoadImage(byte[] data);
        public extern void LoadRawTextureData(byte[] data);
        public extern Rect[] PackTextures(Texture2D[] textures, int padding);
        public extern Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize);
        public extern Rect[] PackTextures(Texture2D[] textures, int padding, int maximumAtlasSize, bool makeNoLongerReadable);
        public extern void ReadPixels(Rect source, int destX, int destY);
        public extern void ReadPixels(Rect source, int destX, int destY, bool recalculateMipMaps);
        public extern bool Resize(int width, int height);
        public extern bool Resize(int width, int height, TextureFormat format, bool hasMipMap);
        public extern void SetPixel(int x, int y, Color color);
        public extern void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors);
        public extern void SetPixels(int x, int y, int blockWidth, int blockHeight, Color[] colors, int miplevel);
        public extern void SetPixels(Color[] colors);
        public extern void SetPixels(Color[] colors, int miplevel);
        public extern void SetPixels32(Color32[] colors);
        public extern void SetPixels32(Color32[] colors, int miplevel);
        public extern void UpdateExternalTexture(System.IntPtr nativeTex);
        public static extern Texture2D CreateExternalTexture(int width, int height, TextureFormat format, bool mipmap, bool linear, System.IntPtr nativeTex);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum ThreadPriority
    {
        Low = 0,
        BelowNormal = 1,
        Normal = 2,
        High = 4,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AudioType
    {
        UNKNOWN = 0,
        ACC = 1,
        AIFF = 2,
        IT = 10,
        MOD = 12,
        MPEG = 13,
        OGGVORBIS = 14,
        S3M = 17,
        WAV = 20,
        XM = 21,
        XMA = 22,
        VAG = 23,
        AUDIOQUEUE = 24,
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public class Encoding : System.ICloneable
    {
        public virtual string BodyName { get { return default(string); } }
        public virtual int CodePage { get { return default(int); } }
        public DecoderFallback DecoderFallback { get { return default(DecoderFallback); } set {} }
        public EncoderFallback EncoderFallback { get { return default(EncoderFallback); } set {} }
        public virtual string EncodingName { get { return default(string); } }
        public virtual string HeaderName { get { return default(string); } }
        public virtual bool IsBrowserDisplay { get { return default(bool); } }
        public virtual bool IsBrowserSave { get { return default(bool); } }
        public virtual bool IsMailNewsDisplay { get { return default(bool); } }
        public virtual bool IsMailNewsSave { get { return default(bool); } }
        public bool IsReadOnly { get { return default(bool); } }
        public virtual bool IsSingleByte { get { return default(bool); } }
        public virtual string WebName { get { return default(string); } }
        public virtual int WindowsCodePage { get { return default(int); } }
        public static Encoding ASCII { get { return default(Encoding); } }
        public static Encoding BigEndianUnicode { get { return default(Encoding); } }
        public static Encoding Default { get { return default(Encoding); } }
        public static Encoding Unicode { get { return default(Encoding); } }
        public static Encoding UTF32 { get { return default(Encoding); } }
        public static Encoding UTF7 { get { return default(Encoding); } }
        public static Encoding UTF8 { get { return default(Encoding); } }
         
         
        public extern virtual object Clone();
        public extern override bool Equals(object value);
        public extern virtual int GetByteCount(System.Char[] chars);
        public extern virtual int GetByteCount(System.Char[] chars, int index, int count);
        public extern virtual int GetByteCount(string s);
        public extern virtual byte[] GetBytes(System.Char[] chars);
        public extern virtual byte[] GetBytes(System.Char[] chars, int index, int count);
        public extern virtual byte[] GetBytes(string s);
        public extern virtual int GetBytes(System.Char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex);
        public extern virtual int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex);
        public extern virtual int GetCharCount(byte[] bytes);
        public extern virtual int GetCharCount(byte[] bytes, int index, int count);
        public extern virtual System.Char[] GetChars(byte[] bytes);
        public extern virtual System.Char[] GetChars(byte[] bytes, int index, int count);
        public extern virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, System.Char[] chars, int charIndex);
        public extern virtual Decoder GetDecoder();
        public extern virtual Encoder GetEncoder();
        public extern override int GetHashCode();
        public extern virtual int GetMaxByteCount(int charCount);
        public extern virtual int GetMaxCharCount(int byteCount);
        public extern virtual byte[] GetPreamble();
        public extern virtual string GetString(byte[] bytes);
        public extern virtual string GetString(byte[] bytes, int index, int count);
        public extern bool IsAlwaysNormalized();
        public extern virtual bool IsAlwaysNormalized(NormalizationForm form);
        public static extern byte[] Convert(Encoding srcEncoding, Encoding dstEncoding, byte[] bytes);
        public static extern byte[] Convert(Encoding srcEncoding, Encoding dstEncoding, byte[] bytes, int index, int count);
        public static extern Encoding GetEncoding(int codepage);
        public static extern Encoding GetEncoding(int codepage, EncoderFallback encoderFallback, DecoderFallback decoderFallback);
        public static extern Encoding GetEncoding(string name);
        public static extern Encoding GetEncoding(string name, EncoderFallback encoderFallback, DecoderFallback decoderFallback);
        public static extern EncodingInfo[] GetEncodings();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum HideFlags
    {
        None = 0,
        HideInHierarchy = 1,
        HideInInspector = 2,
        DontSave = 4,
        NotEditable = 8,
        HideAndDontSave = 13,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum NetworkReachability
    {
        NotReachable = 0,
        ReachableViaCarrierDataNetwork = 1,
        ReachableViaLocalAreaNetwork = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RuntimePlatform
    {
        OSXEditor = 0,
        OSXPlayer = 1,
        WindowsPlayer = 2,
        OSXWebPlayer = 3,
        OSXDashboardPlayer = 4,
        WindowsWebPlayer = 5,
        WindowsEditor = 7,
        IPhonePlayer = 8,
        XBOX360 = 10,
        PS3 = 9,
        Android = 11,
        NaCl = 12,
        LinuxPlayer = 13,
        FlashPlayer = 15,
        MetroPlayerX86 = 18,
        MetroPlayerX64 = 19,
        MetroPlayerARM = 20,
        WP8Player = 21,
        BB10Player = 22,
        BlackBerryPlayer = 22,
        TizenPlayer = 23,
        PSP2 = 24,
        PS4 = 25,
        PSMPlayer = 26,
        XboxOne = 27,
        SamsungTVPlayer = 28,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum SystemLanguage
    {
        Afrikaans = 0,
        Arabic = 1,
        Basque = 2,
        Belarusian = 3,
        Bulgarian = 4,
        Catalan = 5,
        Chinese = 6,
        Czech = 7,
        Danish = 8,
        Dutch = 9,
        English = 10,
        Estonian = 11,
        Faroese = 12,
        Finnish = 13,
        French = 14,
        German = 15,
        Greek = 16,
        Hebrew = 17,
        Hugarian = 18,
        Icelandic = 19,
        Indonesian = 20,
        Italian = 21,
        Japanese = 22,
        Korean = 23,
        Latvian = 24,
        Lithuanian = 25,
        Norwegian = 26,
        Polish = 27,
        Portuguese = 28,
        Romanian = 29,
        Russian = 30,
        SerboCroatian = 31,
        Slovak = 32,
        Slovenian = 33,
        Spanish = 34,
        Swedish = 35,
        Thai = 36,
        Turkish = 37,
        Ukrainian = 38,
        Vietnamese = 39,
        Unknown = 40,
        Hungarian = 18,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum UserAuthorization
    {
        WebCam = 1,
        Microphone = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AsyncOperation : YieldInstruction
    {
        public extern AsyncOperation();
         
        public bool allowSceneActivation { get { return default(bool); } set {} }
        public bool isDone { get { return default(bool); } }
        public int priority { get { return default(int); } set {} }
        public float progress { get { return default(float); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class ResourceRequest : AsyncOperation
    {
        public extern ResourceRequest();
         
        public Object asset { get { return default(Object); } }
         
         
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public class PointerEventData : BaseEventData
    {
            [Bridge.FileName("csw")]
            public enum InputButton
            {
                Left = 0,
                Right = 1,
                Middle = 2,
            }
        public extern PointerEventData(EventSystem eventSystem);
         
        public PointerEventData.InputButton button { get { return default(PointerEventData.InputButton); } set {} }
        public int clickCount { get { return default(int); } set {} }
        public float clickTime { get { return default(float); } set {} }
        public UnityEngine.Vector2 delta { get { return default(UnityEngine.Vector2); } set {} }
        public bool dragging { get { return default(bool); } set {} }
        public bool eligibleForClick { get { return default(bool); } set {} }
        public UnityEngine.Camera enterEventCamera { get { return default(UnityEngine.Camera); } }
        public RaycastResult pointerCurrentRaycast { get { return default(RaycastResult); } set {} }
        public UnityEngine.GameObject pointerDrag { get { return default(UnityEngine.GameObject); } set {} }
        public UnityEngine.GameObject pointerEnter { get { return default(UnityEngine.GameObject); } set {} }
        public int pointerId { get { return default(int); } set {} }
        public UnityEngine.GameObject pointerPress { get { return default(UnityEngine.GameObject); } set {} }
        public RaycastResult pointerPressRaycast { get { return default(RaycastResult); } set {} }
        public UnityEngine.Vector2 position { get { return default(UnityEngine.Vector2); } set {} }
        public UnityEngine.Camera pressEventCamera { get { return default(UnityEngine.Camera); } }
        public UnityEngine.Vector2 pressPosition { get { return default(UnityEngine.Vector2); } set {} }
        public UnityEngine.GameObject rawPointerPress { get { return default(UnityEngine.GameObject); } set {} }
        public UnityEngine.Vector2 scrollDelta { get { return default(UnityEngine.Vector2); } set {} }
        public bool useDragThreshold { get { return default(bool); } set {} }
         
         
        public extern bool IsPointerMoving();
        public extern bool IsScrolling();
        public extern override string ToString();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Shader : Object
    {
        public extern Shader();
         
        public bool isSupported { get { return default(bool); } }
        public int maximumLOD { get { return default(int); } set {} }
        public int renderQueue { get { return default(int); } }
        public static int globalMaximumLOD { get { return default(int); } set {} }
         
         
        public static extern void DisableKeyword(string keyword);
        public static extern void EnableKeyword(string keyword);
        public static extern Shader Find(string name);
        public static extern int PropertyToID(string name);
        public static extern void SetGlobalBuffer(string propertyName, ComputeBuffer buffer);
        public static extern void SetGlobalColor(int nameID, Color color);
        public static extern void SetGlobalColor(string propertyName, Color color);
        public static extern void SetGlobalFloat(int nameID, float value);
        public static extern void SetGlobalFloat(string propertyName, float value);
        public static extern void SetGlobalInt(int nameID, int value);
        public static extern void SetGlobalInt(string propertyName, int value);
        public static extern void SetGlobalMatrix(int nameID, Matrix4x4 mat);
        public static extern void SetGlobalMatrix(string propertyName, Matrix4x4 mat);
        public static extern void SetGlobalTexGenMode(string propertyName, TexGenMode mode);
        public static extern void SetGlobalTexture(int nameID, Texture tex);
        public static extern void SetGlobalTexture(string propertyName, Texture tex);
        public static extern void SetGlobalTextureMatrixName(string propertyName, string matrixName);
        public static extern void SetGlobalVector(int nameID, Vector4 vec);
        public static extern void SetGlobalVector(string propertyName, Vector4 vec);
        public static extern void WarmupAllShaders();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Texture : Object
    {
        public extern Texture();
         
        public int anisoLevel { get { return default(int); } set {} }
        public FilterMode filterMode { get { return default(FilterMode); } set {} }
        public virtual int height { get { return default(int); } set {} }
        public float mipMapBias { get { return default(float); } set {} }
        public Vector2 texelSize { get { return default(Vector2); } }
        public virtual int width { get { return default(int); } set {} }
        public TextureWrapMode wrapMode { get { return default(TextureWrapMode); } set {} }
        public static AnisotropicFiltering anisotropicFiltering { get { return default(AnisotropicFiltering); } set {} }
        public static int masterTextureLimit { get { return default(int); } set {} }
         
         
        public extern int GetNativeTextureID();
        public extern System.IntPtr GetNativeTexturePtr();
        public static extern void SetGlobalAnisotropicFilteringLimits(int forcedMin, int globalMax);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Matrix4x4
    {
        public float m00;
        public float m10;
        public float m20;
        public float m30;
        public float m01;
        public float m11;
        public float m21;
        public float m31;
        public float m02;
        public float m12;
        public float m22;
        public float m32;
        public float m03;
        public float m13;
        public float m23;
        public float m33;
         
         
        public Matrix4x4 inverse { get { return default(Matrix4x4); } }
        public bool isIdentity { get { return default(bool); } }
        public Matrix4x4 transpose { get { return default(Matrix4x4); } }
        public static Matrix4x4 identity { get { return default(Matrix4x4); } }
        public static Matrix4x4 zero { get { return default(Matrix4x4); } }
         
        public float this[int index] { get { return default(float); } set {} }
        public float this[int row, int column] { get { return default(float); } set {} }
         
        public static extern bool operator ==(Matrix4x4 lhs, Matrix4x4 rhs);
        public static extern bool operator !=(Matrix4x4 lhs, Matrix4x4 rhs);
        public static extern Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs);
        public static extern Vector4 operator *(Matrix4x4 lhs, Vector4 v);
         
        public extern override bool Equals(object other);
        public extern Vector4 GetColumn(int i);
        public extern override int GetHashCode();
        public extern Vector4 GetRow(int i);
        public extern Vector3 MultiplyPoint(Vector3 v);
        public extern Vector3 MultiplyPoint3x4(Vector3 v);
        public extern Vector3 MultiplyVector(Vector3 v);
        public extern void SetColumn(int i, Vector4 v);
        public extern void SetRow(int i, Vector4 v);
        public extern void SetTRS(Vector3 pos, Quaternion q, Vector3 s);
        public extern override string ToString();
        public extern string ToString(string format);
        public static extern Matrix4x4 Inverse(Matrix4x4 m);
        public static extern Matrix4x4 Ortho(float left, float right, float bottom, float top, float zNear, float zFar);
        public static extern Matrix4x4 Perspective(float fov, float aspect, float zNear, float zFar);
        public static extern Matrix4x4 Scale(Vector3 v);
        public static extern Matrix4x4 Transpose(Matrix4x4 m);
        public static extern Matrix4x4 TRS(Vector3 pos, Quaternion q, Vector3 s);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class ComputeBuffer : System.IDisposable
    {
        public extern ComputeBuffer(int count, int stride);
        public extern ComputeBuffer(int count, int stride, ComputeBufferType type);
         
        public int count { get { return default(int); } }
        public int stride { get { return default(int); } }
         
         
        public extern virtual void Dispose();
        public extern void GetData(System.Array data);
        public extern void Release();
        public extern void SetData(System.Array data);
        public static extern void CopyCount(ComputeBuffer src, ComputeBuffer dst, int dstOffset);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class ConstantForce : Behaviour
    {
        public extern ConstantForce();
         
        public Vector3 force { get { return default(Vector3); } set {} }
        public Vector3 relativeForce { get { return default(Vector3); } set {} }
        public Vector3 relativeTorque { get { return default(Vector3); } set {} }
        public Vector3 torque { get { return default(Vector3); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class HingeJoint : Joint
    {
        public extern HingeJoint();
         
        public float angle { get { return default(float); } }
        public JointLimits limits { get { return default(JointLimits); } set {} }
        public JointMotor motor { get { return default(JointMotor); } set {} }
        public JointSpring spring { get { return default(JointSpring); } set {} }
        public bool useLimits { get { return default(bool); } set {} }
        public bool useMotor { get { return default(bool); } set {} }
        public bool useSpring { get { return default(bool); } set {} }
        public float velocity { get { return default(float); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class ParticleEmitter : Component
    {
        public extern ParticleEmitter();
         
        public float angularVelocity { get { return default(float); } set {} }
        public bool emit { get { return default(bool); } set {} }
        public float emitterVelocityScale { get { return default(float); } set {} }
        public bool enabled { get { return default(bool); } set {} }
        public Vector3 localVelocity { get { return default(Vector3); } set {} }
        public float maxEmission { get { return default(float); } set {} }
        public float maxEnergy { get { return default(float); } set {} }
        public float maxSize { get { return default(float); } set {} }
        public float minEmission { get { return default(float); } set {} }
        public float minEnergy { get { return default(float); } set {} }
        public float minSize { get { return default(float); } set {} }
        public int particleCount { get { return default(int); } }
        public Particle[] particles { get { return default(Particle[]); } set {} }
        public float rndAngularVelocity { get { return default(float); } set {} }
        public bool rndRotation { get { return default(bool); } set {} }
        public Vector3 rndVelocity { get { return default(Vector3); } set {} }
        public bool useWorldSpace { get { return default(bool); } set {} }
        public Vector3 worldVelocity { get { return default(Vector3); } set {} }
         
         
        public extern void ClearParticles();
        public extern void Emit();
        public extern void Emit(int count);
        public extern void Emit(Vector3 pos, Vector3 velocity, float size, float energy, Color color);
        public extern void Emit(Vector3 pos, Vector3 velocity, float size, float energy, Color color, float rotation, float angularVelocity);
        public extern void Simulate(float deltaTime);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum SendMessageOptions
    {
        RequireReceiver = 0,
        DontRequireReceiver = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AnimationClip : Motion
    {
        public extern AnimationClip();
         
        public float frameRate { get { return default(float); } set {} }
        public float length { get { return default(float); } }
        public Bounds localBounds { get { return default(Bounds); } set {} }
        public WrapMode wrapMode { get { return default(WrapMode); } set {} }
         
         
        public extern void AddEvent(AnimationEvent evt);
        public extern void ClearCurves();
        public extern void EnsureQuaternionContinuity();
        public extern void SetCurve(string relativePath, System.Type type, string propertyName, AnimationCurve curve);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum PrimitiveType
    {
        Sphere = 0,
        Capsule = 1,
        Cylinder = 2,
        Cube = 3,
        Plane = 4,
        Quad = 5,
    }
}
 
namespace UnityEngine.Events
{
    [Bridge.FileName("csw")]
    public enum UnityEventCallState
    {
        Off = 0,
        EditorAndRuntime = 1,
        RuntimeOnly = 2,
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public class BaseEventData
    {
        public extern BaseEventData(EventSystem eventSystem);
         
        public BaseInputModule currentInputModule { get { return default(BaseInputModule); } }
        public UnityEngine.GameObject selectedObject { get { return default(UnityEngine.GameObject); } set {} }
        public bool used { get { return default(bool); } }
         
         
        public extern void Reset();
        public extern void Use();
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public class AxisEventData : BaseEventData
    {
        public extern AxisEventData(EventSystem eventSystem);
         
        public MoveDirection moveDir { get { return default(MoveDirection); } set {} }
        public UnityEngine.Vector2 moveVector { get { return default(UnityEngine.Vector2); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Bounds
    {
        public extern Bounds(Vector3 center, Vector3 size);
         
        public Vector3 center { get { return default(Vector3); } set {} }
        public Vector3 extents { get { return default(Vector3); } set {} }
        public Vector3 max { get { return default(Vector3); } set {} }
        public Vector3 min { get { return default(Vector3); } set {} }
        public Vector3 size { get { return default(Vector3); } set {} }
         
         
        public static extern bool operator ==(Bounds lhs, Bounds rhs);
        public static extern bool operator !=(Bounds lhs, Bounds rhs);
         
        public extern bool Contains(Vector3 point);
        public extern void Encapsulate(Bounds bounds);
        public extern void Encapsulate(Vector3 point);
        public extern override bool Equals(object other);
        public extern void Expand(float amount);
        public extern void Expand(Vector3 amount);
        public extern override int GetHashCode();
        public extern bool IntersectRay(Ray ray);
        public extern bool IntersectRay(Ray ray, out float distance);
        public extern bool Intersects(Bounds bounds);
        public extern void SetMinMax(Vector3 min, Vector3 max);
        public extern float SqrDistance(Vector3 point);
        public extern override string ToString();
        public extern string ToString(string format);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum SpritePackingMode
    {
        Tight = 0,
        Rectangle = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum SpritePackingRotation
    {
        None = 0,
        Any = 15,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum SpriteMeshType
    {
        FullRect = 0,
        Tight = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum CollisionDetectionMode
    {
        Discrete = 0,
        Continuous = 1,
        ContinuousDynamic = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RigidbodyConstraints
    {
        None = 0,
        FreezePositionX = 2,
        FreezePositionY = 4,
        FreezePositionZ = 8,
        FreezeRotationX = 16,
        FreezeRotationY = 32,
        FreezeRotationZ = 64,
        FreezePosition = 14,
        FreezeRotation = 112,
        FreezeAll = 126,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RigidbodyInterpolation
    {
        None = 0,
        Interpolate = 1,
        Extrapolate = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum ForceMode
    {
        Force = 0,
        Acceleration = 5,
        Impulse = 1,
        VelocityChange = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum Space
    {
        World = 0,
        Self = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum CollisionDetectionMode2D
    {
        None = 0,
        Continuous = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RigidbodyInterpolation2D
    {
        None = 0,
        Interpolate = 1,
        Extrapolate = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RigidbodySleepMode2D
    {
        NeverSleep = 0,
        StartAwake = 1,
        StartAsleep = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum ForceMode2D
    {
        Force = 0,
        Impulse = 1,
    }
}
 
namespace UnityEngine.Events
{
    public delegate void UnityAction();
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum ParticleSystemSimulationSpace
    {
        Local = 0,
        World = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Color32
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;
         
        public extern Color32(byte r, byte g, byte b, byte a);
         
        public static extern implicit operator Color(Color32 c);
        public static extern implicit operator Color32(Color c);
         
        public extern override string ToString();
        public extern string ToString(string format);
        public static extern Color32 Lerp(Color32 a, Color32 b, float t);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class PhysicMaterial : Object
    {
        public extern PhysicMaterial();
        public extern PhysicMaterial(string name);
         
        public PhysicMaterialCombine bounceCombine { get { return default(PhysicMaterialCombine); } set {} }
        public float bounciness { get { return default(float); } set {} }
        public float dynamicFriction { get { return default(float); } set {} }
        public float dynamicFriction2 { get { return default(float); } set {} }
        public PhysicMaterialCombine frictionCombine { get { return default(PhysicMaterialCombine); } set {} }
        public Vector3 frictionDirection2 { get { return default(Vector3); } set {} }
        public float staticFriction { get { return default(float); } set {} }
        public float staticFriction2 { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class MaterialPropertyBlock
    {
        public extern MaterialPropertyBlock();
         
        public bool isEmpty { get { return default(bool); } }
         
         
        public extern void AddColor(int nameID, Color value);
        public extern void AddColor(string name, Color value);
        public extern void AddFloat(int nameID, float value);
        public extern void AddFloat(string name, float value);
        public extern void AddMatrix(int nameID, Matrix4x4 value);
        public extern void AddMatrix(string name, Matrix4x4 value);
        public extern void AddTexture(int nameID, Texture value);
        public extern void AddTexture(string name, Texture value);
        public extern void AddVector(int nameID, Vector4 value);
        public extern void AddVector(string name, Vector4 value);
        public extern void Clear();
        public extern float GetFloat(int nameID);
        public extern float GetFloat(string name);
        public extern Matrix4x4 GetMatrix(int nameID);
        public extern Matrix4x4 GetMatrix(string name);
        public extern Texture GetTexture(int nameID);
        public extern Texture GetTexture(string name);
        public extern Vector4 GetVector(int nameID);
        public extern Vector4 GetVector(string name);
        public extern void SetColor(int nameID, Color value);
        public extern void SetColor(string name, Color value);
        public extern void SetFloat(int nameID, float value);
        public extern void SetFloat(string name, float value);
        public extern void SetMatrix(int nameID, Matrix4x4 value);
        public extern void SetMatrix(string name, Matrix4x4 value);
        public extern void SetTexture(int nameID, Texture value);
        public extern void SetTexture(string name, Texture value);
        public extern void SetVector(int nameID, Vector4 value);
        public extern void SetVector(string name, Vector4 value);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Flare : Object
    {
        public extern Flare();
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum LightRenderMode
    {
        Auto = 0,
        ForcePixel = 1,
        ForceVertex = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum LightShadows
    {
        None = 0,
        Hard = 1,
        Soft = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum LightType
    {
        Spot = 0,
        Directional = 1,
        Point = 2,
        Area = 3,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class PhysicsMaterial2D : Object
    {
        public extern PhysicsMaterial2D();
        public extern PhysicsMaterial2D(string name);
         
        public float bounciness { get { return default(float); } set {} }
        public float friction { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Coroutine : YieldInstruction
    {
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct OffMeshLinkData
    {
         
        public bool activated { get { return default(bool); } }
        public Vector3 endPos { get { return default(Vector3); } }
        public OffMeshLinkType linkType { get { return default(OffMeshLinkType); } }
        public OffMeshLink offMeshLink { get { return default(OffMeshLink); } }
        public Vector3 startPos { get { return default(Vector3); } }
        public bool valid { get { return default(bool); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum ObstacleAvoidanceType
    {
        NoObstacleAvoidance = 0,
        LowQualityObstacleAvoidance = 1,
        MedQualityObstacleAvoidance = 2,
        GoodQualityObstacleAvoidance = 3,
        HighQualityObstacleAvoidance = 4,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct NavMeshHit
    {
         
        public float distance { get { return default(float); } set {} }
        public bool hit { get { return default(bool); } set {} }
        public int mask { get { return default(int); } set {} }
        public Vector3 normal { get { return default(Vector3); } set {} }
        public Vector3 position { get { return default(Vector3); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Mesh : Object
    {
        public extern Mesh();
         
        public Matrix4x4[] bindposes { get { return default(Matrix4x4[]); } set {} }
        public int blendShapeCount { get { return default(int); } }
        public BoneWeight[] boneWeights { get { return default(BoneWeight[]); } set {} }
        public Bounds bounds { get { return default(Bounds); } set {} }
        public Color[] colors { get { return default(Color[]); } set {} }
        public Color32[] colors32 { get { return default(Color32[]); } set {} }
        public bool isReadable { get { return default(bool); } }
        public Vector3[] normals { get { return default(Vector3[]); } set {} }
        public int subMeshCount { get { return default(int); } set {} }
        public Vector4[] tangents { get { return default(Vector4[]); } set {} }
        public int[] triangles { get { return default(int[]); } set {} }
        public Vector2[] uv { get { return default(Vector2[]); } set {} }
        public Vector2[] uv1 { get { return default(Vector2[]); } set {} }
        public Vector2[] uv2 { get { return default(Vector2[]); } set {} }
        public int vertexCount { get { return default(int); } }
        public Vector3[] vertices { get { return default(Vector3[]); } set {} }
         
         
        public extern void Clear();
        public extern void Clear(bool keepVertexLayout);
        public extern void CombineMeshes(CombineInstance[] combine);
        public extern void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes);
        public extern void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes, bool useMatrices);
        public extern int GetBlendShapeIndex(string blendShapeName);
        public extern string GetBlendShapeName(int index);
        public extern int[] GetIndices(int submesh);
        public extern MeshTopology GetTopology(int submesh);
        public extern int[] GetTriangles(int submesh);
        public extern void MarkDynamic();
        public extern void Optimize();
        public extern void RecalculateBounds();
        public extern void RecalculateNormals();
        public extern void SetIndices(int[] indices, MeshTopology topology, int submesh);
        public extern void SetTriangles(int[] triangles, int submesh);
        public extern void UploadMeshData(bool markNoLogerReadable);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum ParticleSystemRenderMode
    {
        Billboard = 0,
        Stretch = 1,
        HorizontalBillboard = 2,
        VerticalBillboard = 3,
        Mesh = 4,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AudioRolloffMode
    {
        Logarithmic = 0,
        Linear = 1,
        Custom = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AudioVelocityUpdateMode
    {
        Auto = 0,
        Fixed = 1,
        Dynamic = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum FFTWindow
    {
        Rectangular = 0,
        Triangle = 1,
        Hamming = 2,
        Hanning = 3,
        Blackman = 4,
        BlackmanHarris = 5,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RenderingPath
    {
        UsePlayerSettings = -1,
        VertexLit = 0,
        Forward = 1,
        DeferredLighting = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum CameraClearFlags
    {
        Skybox = 1,
        Color = 2,
        SolidColor = 2,
        Depth = 3,
        Nothing = 4,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum DepthTextureMode
    {
        None = 0,
        Depth = 1,
        DepthNormals = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class RenderTexture : Texture
    {
        public extern RenderTexture(int width, int height, int depth);
        public extern RenderTexture(int width, int height, int depth, RenderTextureFormat format);
        public extern RenderTexture(int width, int height, int depth, RenderTextureFormat format, RenderTextureReadWrite readWrite);
         
        public int antiAliasing { get { return default(int); } set {} }
        public RenderBuffer colorBuffer { get { return default(RenderBuffer); } }
        public int depth { get { return default(int); } set {} }
        public RenderBuffer depthBuffer { get { return default(RenderBuffer); } }
        public bool enableRandomWrite { get { return default(bool); } set {} }
        public RenderTextureFormat format { get { return default(RenderTextureFormat); } set {} }
        public bool generateMips { get { return default(bool); } set {} }
        public override int height { get { return default(int); } set {} }
        public bool isCubemap { get { return default(bool); } set {} }
        public bool isPowerOfTwo { get { return default(bool); } set {} }
        public bool isVolume { get { return default(bool); } set {} }
        public bool sRGB { get { return default(bool); } }
        public bool useMipMap { get { return default(bool); } set {} }
        public int volumeDepth { get { return default(int); } set {} }
        public override int width { get { return default(int); } set {} }
        public static RenderTexture active { get { return default(RenderTexture); } set {} }
         
         
        public extern bool Create();
        public extern void DiscardContents();
        public extern void DiscardContents(bool discardColor, bool discardDepth);
        public extern Vector2 GetTexelOffset();
        public extern bool IsCreated();
        public extern void MarkRestoreExpected();
        public extern void Release();
        public extern void SetGlobalShaderProperty(string propertyName);
        public static extern RenderTexture GetTemporary(int width, int height);
        public static extern RenderTexture GetTemporary(int width, int height, int depthBuffer);
        public static extern RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format);
        public static extern RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite);
        public static extern RenderTexture GetTemporary(int width, int height, int depthBuffer, RenderTextureFormat format, RenderTextureReadWrite readWrite, int antiAliasing);
        public static extern void ReleaseTemporary(RenderTexture temp);
        public static extern bool SupportsStencil(RenderTexture rt);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum TransparencySortMode
    {
        Default = 0,
        Perspective = 1,
        Orthographic = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Cubemap : Texture
    {
        public extern Cubemap(int size, TextureFormat format, bool mipmap);
         
        public TextureFormat format { get { return default(TextureFormat); } }
         
         
        public extern void Apply();
        public extern void Apply(bool updateMipmaps);
        public extern void Apply(bool updateMipmaps, bool makeNoLongerReadable);
        public extern Color GetPixel(CubemapFace face, int x, int y);
        public extern Color[] GetPixels(CubemapFace face);
        public extern Color[] GetPixels(CubemapFace face, int miplevel);
        public extern void SetPixel(CubemapFace face, int x, int y, Color color);
        public extern void SetPixels(Color[] colors, CubemapFace face);
        public extern void SetPixels(Color[] colors, CubemapFace face, int miplevel);
        public extern void SmoothEdges();
        public extern void SmoothEdges(int smoothRegionWidthInPixels);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct RenderBuffer
    {
         
        public extern System.IntPtr GetNativeRenderBufferPtr();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Avatar : Object
    {
        public extern Avatar();
         
        public bool isHuman { get { return default(bool); } }
        public bool isValid { get { return default(bool); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AnimatorCullingMode
    {
        AlwaysAnimate = 0,
        BasedOnRenderers = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class RuntimeAnimatorController : Object
    {
        public extern RuntimeAnimatorController();
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AnimatorUpdateMode
    {
        Normal = 0,
        AnimatePhysics = 1,
        UnscaledTime = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct AnimatorTransitionInfo
    {
         
        public int nameHash { get { return default(int); } }
        public float normalizedTime { get { return default(float); } }
        public int userNameHash { get { return default(int); } }
         
         
        public extern bool IsName(string name);
        public extern bool IsUserName(string name);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum HumanBodyBones
    {
        Hips = 0,
        LeftUpperLeg = 1,
        RightUpperLeg = 2,
        LeftLowerLeg = 3,
        RightLowerLeg = 4,
        LeftFoot = 5,
        RightFoot = 6,
        Spine = 7,
        Chest = 8,
        Neck = 9,
        Head = 10,
        LeftShoulder = 11,
        RightShoulder = 12,
        LeftUpperArm = 13,
        RightUpperArm = 14,
        LeftLowerArm = 15,
        RightLowerArm = 16,
        LeftHand = 17,
        RightHand = 18,
        LeftToes = 19,
        RightToes = 20,
        LeftEye = 21,
        RightEye = 22,
        Jaw = 23,
        LeftThumbProximal = 24,
        LeftThumbIntermediate = 25,
        LeftThumbDistal = 26,
        LeftIndexProximal = 27,
        LeftIndexIntermediate = 28,
        LeftIndexDistal = 29,
        LeftMiddleProximal = 30,
        LeftMiddleIntermediate = 31,
        LeftMiddleDistal = 32,
        LeftRingProximal = 33,
        LeftRingIntermediate = 34,
        LeftRingDistal = 35,
        LeftLittleProximal = 36,
        LeftLittleIntermediate = 37,
        LeftLittleDistal = 38,
        RightThumbProximal = 39,
        RightThumbIntermediate = 40,
        RightThumbDistal = 41,
        RightIndexProximal = 42,
        RightIndexIntermediate = 43,
        RightIndexDistal = 44,
        RightMiddleProximal = 45,
        RightMiddleIntermediate = 46,
        RightMiddleDistal = 47,
        RightRingProximal = 48,
        RightRingIntermediate = 49,
        RightRingDistal = 50,
        RightLittleProximal = 51,
        RightLittleIntermediate = 52,
        RightLittleDistal = 53,
        LastBone = 54,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct AnimationInfo
    {
         
        public AnimationClip clip { get { return default(AnimationClip); } }
        public float weight { get { return default(float); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AvatarIKGoal
    {
        LeftFoot = 0,
        RightFoot = 1,
        LeftHand = 2,
        RightHand = 3,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AvatarTarget
    {
        Root = 0,
        Body = 1,
        LeftFoot = 2,
        RightFoot = 3,
        LeftHand = 4,
        RightHand = 5,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct MatchTargetWeightMask
    {
        public extern MatchTargetWeightMask(Vector3 positionXYZWeight, float rotationWeight);
         
        public Vector3 positionXYZWeight { get { return default(Vector3); } set {} }
        public float rotationWeight { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AnimationCullingType
    {
        AlwaysAnimate = 0,
        BasedOnRenderers = 1,
        BasedOnClipBounds = 2,
        BasedOnUserBounds = 3,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum WrapMode
    {
        Once = 1,
        Loop = 2,
        PingPong = 4,
        Default = 0,
        ClampForever = 8,
        Clamp = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AnimationState : TrackedReference
    {
        public extern AnimationState();
         
        public AnimationBlendMode blendMode { get { return default(AnimationBlendMode); } set {} }
        public AnimationClip clip { get { return default(AnimationClip); } }
        public bool enabled { get { return default(bool); } set {} }
        public int layer { get { return default(int); } set {} }
        public float length { get { return default(float); } }
        public string name { get { return default(string); } set {} }
        public float normalizedSpeed { get { return default(float); } set {} }
        public float normalizedTime { get { return default(float); } set {} }
        public float speed { get { return default(float); } set {} }
        public float time { get { return default(float); } set {} }
        public float weight { get { return default(float); } set {} }
        public WrapMode wrapMode { get { return default(WrapMode); } set {} }
         
         
        public extern void AddMixingTransform(Transform mix);
        public extern void AddMixingTransform(Transform mix, bool recursive);
        public extern void RemoveMixingTransform(Transform mix);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum PlayMode
    {
        StopSameLayer = 0,
        StopAll = 4,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum QueueMode
    {
        CompleteOthers = 0,
        PlayNow = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum TextAlignment
    {
        Left = 0,
        Center = 1,
        Right = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum TextAnchor
    {
        UpperLeft = 0,
        UpperCenter = 1,
        UpperRight = 2,
        MiddleLeft = 3,
        MiddleCenter = 4,
        MiddleRight = 5,
        LowerLeft = 6,
        LowerCenter = 7,
        LowerRight = 8,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Font : Object
    {
        public extern Font();
        public extern Font(string name);
         
        public CharacterInfo[] characterInfo { get { return default(CharacterInfo[]); } set {} }
        public bool dynamic { get { return default(bool); } }
        public string[] fontNames { get { return default(string[]); } set {} }
        public int fontSize { get { return default(int); } }
        public Material material { get { return default(Material); } set {} }
         
         
        public extern bool GetCharacterInfo(System.Char ch, out CharacterInfo info);
        public extern bool GetCharacterInfo(System.Char ch, out CharacterInfo info, int size);
        public extern bool GetCharacterInfo(System.Char ch, out CharacterInfo info, int size, FontStyle style);
        public extern bool HasCharacter(System.Char c);
        public extern void RequestCharactersInTexture(string characters);
        public extern void RequestCharactersInTexture(string characters, int size);
        public extern void RequestCharactersInTexture(string characters, int size, FontStyle style);
        public static extern int GetMaxVertsForString(string str);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum FontStyle
    {
        Normal = 0,
        Bold = 1,
        Italic = 2,
        BoldAndItalic = 3,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class RectOffset
    {
        public extern RectOffset();
        public extern RectOffset(int left, int right, int top, int bottom);
         
        public int bottom { get { return default(int); } set {} }
        public int horizontal { get { return default(int); } }
        public int left { get { return default(int); } set {} }
        public int right { get { return default(int); } set {} }
        public int top { get { return default(int); } set {} }
        public int vertical { get { return default(int); } }
         
         
        public extern Rect Add(Rect rect);
        public extern Rect Remove(Rect rect);
        public extern override string ToString();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Canvas : Behaviour
    {
        public extern Canvas();
         
        public int cachedSortingLayerValue { get { return default(int); } }
        public bool isRootCanvas { get { return default(bool); } }
        public bool overridePixelPerfect { get { return default(bool); } set {} }
        public bool overrideSorting { get { return default(bool); } set {} }
        public bool pixelPerfect { get { return default(bool); } set {} }
        public Rect pixelRect { get { return default(Rect); } }
        public float planeDistance { get { return default(float); } set {} }
        public float referencePixelsPerUnit { get { return default(float); } set {} }
        public RenderMode renderMode { get { return default(RenderMode); } set {} }
        public int renderOrder { get { return default(int); } }
        public float scaleFactor { get { return default(float); } set {} }
        public int sortingLayerID { get { return default(int); } set {} }
        public string sortingLayerName { get { return default(string); } set {} }
        public int sortingOrder { get { return default(int); } set {} }
        public Camera worldCamera { get { return default(Camera); } set {} }
         
         
        public static extern void ForceUpdateCanvases();
        public static extern Material GetDefaultCanvasMaterial();
        public static extern Material GetDefaultCanvasTextMaterial();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class CanvasRenderer : Component
    {
        public extern CanvasRenderer();
         
        public int absoluteDepth { get { return default(int); } }
        public bool isMask { get { return default(bool); } set {} }
        public int relativeDepth { get { return default(int); } }
         
         
        public extern void Clear();
        public extern float GetAlpha();
        public extern Color GetColor();
        public extern Material GetMaterial();
        public extern void SetAlpha(float alpha);
        public extern void SetColor(Color color);
        public extern void SetMaterial(Material material, Texture texture);
        public extern void SetVertices(System.Collections.Generic.List<UnityEngine.UIVertex> vertices);
        public extern void SetVertices(UIVertex[] vertices, int size);
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class AnimationTriggers
    {
        public extern AnimationTriggers();
         
        public string disabledTrigger { get { return default(string); } set {} }
        public string highlightedTrigger { get { return default(string); } set {} }
        public string normalTrigger { get { return default(string); } set {} }
        public string pressedTrigger { get { return default(string); } set {} }
         
         
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public struct ColorBlock
    {
         
        public float colorMultiplier { get { return default(float); } set {} }
        public UnityEngine.Color disabledColor { get { return default(UnityEngine.Color); } set {} }
        public float fadeDuration { get { return default(float); } set {} }
        public UnityEngine.Color highlightedColor { get { return default(UnityEngine.Color); } set {} }
        public UnityEngine.Color normalColor { get { return default(UnityEngine.Color); } set {} }
        public UnityEngine.Color pressedColor { get { return default(UnityEngine.Color); } set {} }
        public static ColorBlock defaultColorBlock { get { return default(ColorBlock); } }
         
         
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public class Image : MaskableGraphic, UnityEngine.ICanvasRaycastFilter, UnityEngine.ISerializationCallbackReceiver, ILayoutElement
    {
            [Bridge.FileName("csw")]
            public enum FillMethod
            {
                Horizontal = 0,
                Vertical = 1,
                Radial90 = 2,
                Radial180 = 3,
                Radial360 = 4,
            }
            [Bridge.FileName("csw")]
            public enum Type
            {
                Simple = 0,
                Sliced = 1,
                Tiled = 2,
                Filled = 3,
            }
        public float eventAlphaThreshold { get { return default(float); } set {} }
        public float fillAmount { get { return default(float); } set {} }
        public bool fillCenter { get { return default(bool); } set {} }
        public bool fillClockwise { get { return default(bool); } set {} }
        public Image.FillMethod fillMethod { get { return default(Image.FillMethod); } set {} }
        public int fillOrigin { get { return default(int); } set {} }
        public virtual float flexibleHeight { get { return default(float); } }
        public virtual float flexibleWidth { get { return default(float); } }
        public bool hasBorder { get { return default(bool); } }
        public virtual int layoutPriority { get { return default(int); } }
        public override UnityEngine.Texture mainTexture { get { return default(UnityEngine.Texture); } }
        public virtual float minHeight { get { return default(float); } }
        public virtual float minWidth { get { return default(float); } }
        public UnityEngine.Sprite overrideSprite { get { return default(UnityEngine.Sprite); } set {} }
        public float pixelsPerUnit { get { return default(float); } }
        public virtual float preferredHeight { get { return default(float); } }
        public virtual float preferredWidth { get { return default(float); } }
        public bool preserveAspect { get { return default(bool); } set {} }
        public UnityEngine.Sprite sprite { get { return default(UnityEngine.Sprite); } set {} }
        public Image.Type type { get { return default(Image.Type); } set {} }
         
         
        public extern virtual void CalculateLayoutInputHorizontal();
        public extern virtual void CalculateLayoutInputVertical();
        public extern virtual bool IsRaycastLocationValid(UnityEngine.Vector2 screenPoint, UnityEngine.Camera eventCamera);
        public extern virtual void OnAfterDeserialize();
        public extern virtual void OnBeforeSerialize();
        public extern override void SetNativeSize();
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public struct Navigation
    {
            [Bridge.FileName("csw")]
            public enum Mode
            {
                None = 0,
                Horizontal = 1,
                Vertical = 2,
                Automatic = 3,
                Explicit = 4,
            }
         
        public Navigation.Mode mode { get { return default(Navigation.Mode); } set {} }
        public Selectable selectOnDown { get { return default(Selectable); } set {} }
        public Selectable selectOnLeft { get { return default(Selectable); } set {} }
        public Selectable selectOnRight { get { return default(Selectable); } set {} }
        public Selectable selectOnUp { get { return default(Selectable); } set {} }
        public static Navigation defaultNavigation { get { return default(Navigation); } }
         
         
    }
}
 
namespace UnityEngine.UI
{
    [Bridge.FileName("csw")]
    public struct SpriteState
    {
         
        public UnityEngine.Sprite disabledSprite { get { return default(UnityEngine.Sprite); } set {} }
        public UnityEngine.Sprite highlightedSprite { get { return default(UnityEngine.Sprite); } set {} }
        public UnityEngine.Sprite pressedSprite { get { return default(UnityEngine.Sprite); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class TextGenerator : System.IDisposable
    {
        public extern TextGenerator();
        public extern TextGenerator(int initialCapacity);
         
        public int characterCount { get { return default(int); } }
        public int characterCountVisible { get { return default(int); } }
        public System.Collections.Generic.IList<UnityEngine.UICharInfo> characters { get { return default(System.Collections.Generic.IList<UnityEngine.UICharInfo>); } }
        public int fontSizeUsedForBestFit { get { return default(int); } }
        public int lineCount { get { return default(int); } }
        public System.Collections.Generic.IList<UnityEngine.UILineInfo> lines { get { return default(System.Collections.Generic.IList<UnityEngine.UILineInfo>); } }
        public Rect rectExtents { get { return default(Rect); } }
        public int vertexCount { get { return default(int); } }
        public System.Collections.Generic.IList<UnityEngine.UIVertex> verts { get { return default(System.Collections.Generic.IList<UnityEngine.UIVertex>); } }
         
         
        public extern void GetCharacters(System.Collections.Generic.List<UnityEngine.UICharInfo> characters);
        public extern UICharInfo[] GetCharactersArray();
        public extern void GetLines(System.Collections.Generic.List<UnityEngine.UILineInfo> lines);
        public extern UILineInfo[] GetLinesArray();
        public extern float GetPreferredHeight(string str, TextGenerationSettings settings);
        public extern float GetPreferredWidth(string str, TextGenerationSettings settings);
        public extern void GetVertices(System.Collections.Generic.List<UnityEngine.UIVertex> vertices);
        public extern UIVertex[] GetVerticesArray();
        public extern void Invalidate();
        public extern bool Populate(string str, TextGenerationSettings settings);
        public extern void Dispose();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum HorizontalWrapMode
    {
        Wrap = 0,
        Overflow = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum VerticalWrapMode
    {
        Truncate = 0,
        Overflow = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct TextGenerationSettings
    {
        public Font font;
        public Color color;
        public int fontSize;
        public float lineSpacing;
        public bool richText;
        public float scaleFactor;
        public FontStyle fontStyle;
        public TextAnchor textAnchor;
        public bool resizeTextForBestFit;
        public int resizeTextMinSize;
        public int resizeTextMaxSize;
        public bool updateBounds;
        public VerticalWrapMode verticalOverflow;
        public HorizontalWrapMode horizontalOverflow;
        public Vector2 generationExtents;
        public Vector2 pivot;
        public bool generateOutOfBounds;
         
         
        public extern bool Equals(TextGenerationSettings other);
    }
}
 
namespace System.Collections
{
    [Bridge.FileName("csw")]
    public struct DictionaryEntry
    {
        public extern DictionaryEntry(object key, object value);
         
        public object Key { get { return default(object); } set {} }
        public object Value { get { return default(object); } set {} }
         
         
    }
}
 
namespace System.Runtime.Serialization
{
    [Bridge.FileName("csw")]
    public interface IFormatterConverter
    {
        object Convert(object value, System.Type type);
        object Convert(object value, System.TypeCode typeCode);
        bool ToBoolean(object value);
        byte ToByte(object value);
        System.Char ToChar(object value);
        System.DateTime ToDateTime(object value);
        System.Decimal ToDecimal(object value);
        double ToDouble(object value);
        short ToInt16(object value);
        int ToInt32(object value);
        long ToInt64(object value);
        sbyte ToSByte(object value);
        float ToSingle(object value);
        string ToString(object value);
        ushort ToUInt16(object value);
        uint ToUInt32(object value);
        ulong ToUInt64(object value);
    }
}
 
namespace System.Runtime.Serialization
{
    [Bridge.FileName("csw")]
    public class SerializationInfoEnumerator : System.Collections.IEnumerator
    {
        public SerializationEntry Current { get { return default(SerializationEntry); } }
        public string Name { get { return default(string); } }
        public System.Type ObjectType { get { return default(System.Type); } }
        public object Value { get { return default(object); } }
         
         
        public extern virtual bool MoveNext();
        public extern virtual void Reset();
        object System.Collections.IEnumerator.Current { get { return null; } }
    }
}
 
namespace System.Runtime.Serialization
{
    [Bridge.FileName("csw")]
    public enum StreamingContextStates
    {
        CrossProcess = 1,
        CrossMachine = 2,
        File = 4,
        Persistence = 8,
        Remoting = 16,
        Other = 32,
        Clone = 64,
        CrossAppDomain = 128,
        All = 255,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct LocationInfo
    {
         
        public float altitude { get { return default(float); } }
        public float horizontalAccuracy { get { return default(float); } }
        public float latitude { get { return default(float); } }
        public float longitude { get { return default(float); } }
        public double timestamp { get { return default(double); } }
        public float verticalAccuracy { get { return default(float); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum LocationServiceStatus
    {
        Stopped = 0,
        Initializing = 1,
        Running = 2,
        Failed = 3,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum TouchPhase
    {
        Began = 0,
        Moved = 1,
        Stationary = 2,
        Ended = 3,
        Canceled = 4,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AssetBundleRequest : AsyncOperation
    {
        public extern AssetBundleRequest();
         
        public Object asset { get { return default(Object); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AssetBundleCreateRequest : AsyncOperation
    {
        public extern AssetBundleCreateRequest();
         
        public AssetBundle assetBundle { get { return default(AssetBundle); } }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum TextureFormat
    {
        Alpha8 = 1,
        ARGB4444 = 2,
        RGB24 = 3,
        RGBA32 = 4,
        ARGB32 = 5,
        RGB565 = 7,
        DXT1 = 10,
        DXT5 = 12,
        RGBA4444 = 13,
        BGRA32 = 14,
        PVRTC_RGB2 = 30,
        PVRTC_RGBA2 = 31,
        PVRTC_RGB4 = 32,
        PVRTC_RGBA4 = 33,
        ETC_RGB4 = 34,
        ATC_RGB4 = 35,
        ATC_RGBA8 = 36,
        ATF_RGB_DXT1 = 38,
        ATF_RGBA_JPG = 39,
        ATF_RGB_JPG = 40,
        EAC_R = 41,
        EAC_R_SIGNED = 42,
        EAC_RG = 43,
        EAC_RG_SIGNED = 44,
        ETC2_RGB = 45,
        ETC2_RGBA1 = 46,
        ETC2_RGBA8 = 47,
        ASTC_RGB_4x4 = 48,
        ASTC_RGB_5x5 = 49,
        ASTC_RGB_6x6 = 50,
        ASTC_RGB_8x8 = 51,
        ASTC_RGB_10x10 = 52,
        ASTC_RGB_12x12 = 53,
        ASTC_RGBA_4x4 = 54,
        ASTC_RGBA_5x5 = 55,
        ASTC_RGBA_6x6 = 56,
        ASTC_RGBA_8x8 = 57,
        ASTC_RGBA_10x10 = 58,
        ASTC_RGBA_12x12 = 59,
        PVRTC_2BPP_RGB = 30,
        PVRTC_2BPP_RGBA = 31,
        PVRTC_4BPP_RGB = 32,
        PVRTC_4BPP_RGBA = 33,
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public class DecoderFallback
    {
        public virtual int MaxCharCount { get { return default(int); } }
        public static DecoderFallback ExceptionFallback { get { return default(DecoderFallback); } }
        public static DecoderFallback ReplacementFallback { get { return default(DecoderFallback); } }
         
         
        public extern virtual DecoderFallbackBuffer CreateFallbackBuffer();
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public class EncoderFallback
    {
        public virtual int MaxCharCount { get { return default(int); } }
        public static EncoderFallback ExceptionFallback { get { return default(EncoderFallback); } }
        public static EncoderFallback ReplacementFallback { get { return default(EncoderFallback); } }
         
         
        public extern virtual EncoderFallbackBuffer CreateFallbackBuffer();
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public class Decoder
    {
        public DecoderFallback Fallback { get { return default(DecoderFallback); } set {} }
        public DecoderFallbackBuffer FallbackBuffer { get { return default(DecoderFallbackBuffer); } }
         
         
        public extern virtual void Convert(byte[] bytes, int byteIndex, int byteCount, System.Char[] chars, int charIndex, int charCount, bool flush, out int bytesUsed, out int charsUsed, out bool completed);
        public extern virtual int GetCharCount(byte[] bytes, int index, int count);
        public extern virtual int GetCharCount(byte[] bytes, int index, int count, bool flush);
        public extern virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, System.Char[] chars, int charIndex);
        public extern virtual int GetChars(byte[] bytes, int byteIndex, int byteCount, System.Char[] chars, int charIndex, bool flush);
        public extern virtual void Reset();
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public class Encoder
    {
        public EncoderFallback Fallback { get { return default(EncoderFallback); } set {} }
        public EncoderFallbackBuffer FallbackBuffer { get { return default(EncoderFallbackBuffer); } }
         
         
        public extern virtual void Convert(System.Char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, int byteCount, bool flush, out int charsUsed, out int bytesUsed, out bool completed);
        public extern virtual int GetByteCount(System.Char[] chars, int index, int count, bool flush);
        public extern virtual int GetBytes(System.Char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex, bool flush);
        public extern virtual void Reset();
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public enum NormalizationForm
    {
        FormC = 1,
        FormD = 2,
        FormKC = 5,
        FormKD = 6,
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public class EncodingInfo
    {
        public int CodePage { get { return default(int); } }
        public string DisplayName { get { return default(string); } }
        public string Name { get { return default(string); } }
         
         
        public extern override bool Equals(object value);
        public extern Encoding GetEncoding();
        public extern override int GetHashCode();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum LogType
    {
        Error = 0,
        Assert = 1,
        Warning = 2,
        Log = 3,
        Exception = 4,
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public class EventSystem : UIBehaviour
    {
        public bool alreadySelecting { get { return default(bool); } }
        public BaseInputModule currentInputModule { get { return default(BaseInputModule); } }
        public UnityEngine.GameObject currentSelectedGameObject { get { return default(UnityEngine.GameObject); } }
        public UnityEngine.GameObject firstSelectedGameObject { get { return default(UnityEngine.GameObject); } set {} }
        public int pixelDragThreshold { get { return default(int); } set {} }
        public bool sendNavigationEvents { get { return default(bool); } set {} }
        public static EventSystem current { get { return default(EventSystem); } set {} }
         
         
        public extern bool IsPointerOverGameObject();
        public extern bool IsPointerOverGameObject(int pointerId);
        public extern void RaycastAll(PointerEventData eventData, System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> raycastResults);
        public extern void SetSelectedGameObject(UnityEngine.GameObject selected);
        public extern void SetSelectedGameObject(UnityEngine.GameObject selected, BaseEventData pointer);
        public extern override string ToString();
        public extern void UpdateModules();
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public struct RaycastResult
    {
        public BaseRaycaster module;
        public float distance;
        public float index;
        public int depth;
        public int sortingLayer;
        public int sortingOrder;
        public UnityEngine.Vector3 worldPosition;
        public UnityEngine.Vector3 worldNormal;
        public UnityEngine.Vector2 screenPosition;
         
         
        public UnityEngine.GameObject gameObject { get { return default(UnityEngine.GameObject); } set {} }
        public bool isValid { get { return default(bool); } }
         
         
        public extern void Clear();
        public extern override string ToString();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum TexGenMode
    {
        None = 0,
        SphereMap = 1,
        Object = 2,
        EyeLinear = 3,
        CubeReflect = 4,
        CubeNormal = 5,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum FilterMode
    {
        Point = 0,
        Bilinear = 1,
        Trilinear = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum TextureWrapMode
    {
        Repeat = 0,
        Clamp = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AnisotropicFiltering
    {
        Disable = 0,
        Enable = 1,
        ForceEnable = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum ComputeBufferType
    {
        Default = 0,
        Raw = 1,
        Append = 2,
        Counter = 4,
        DrawIndirect = 256,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Joint : Component
    {
        public extern Joint();
         
        public Vector3 anchor { get { return default(Vector3); } set {} }
        public bool autoConfigureConnectedAnchor { get { return default(bool); } set {} }
        public Vector3 axis { get { return default(Vector3); } set {} }
        public float breakForce { get { return default(float); } set {} }
        public float breakTorque { get { return default(float); } set {} }
        public Vector3 connectedAnchor { get { return default(Vector3); } set {} }
        public Rigidbody connectedBody { get { return default(Rigidbody); } set {} }
        public bool enableCollision { get { return default(bool); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct JointLimits
    {
         
        public float max { get { return default(float); } set {} }
        public float maxBounce { get { return default(float); } set {} }
        public float min { get { return default(float); } set {} }
        public float minBounce { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct JointMotor
    {
         
        public float force { get { return default(float); } set {} }
        public bool freeSpin { get { return default(bool); } set {} }
        public float targetVelocity { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct JointSpring
    {
        public float spring;
        public float damper;
        public float targetPosition;
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Particle
    {
         
        public float angularVelocity { get { return default(float); } set {} }
        public Color color { get { return default(Color); } set {} }
        public float energy { get { return default(float); } set {} }
        public Vector3 position { get { return default(Vector3); } set {} }
        public float rotation { get { return default(float); } set {} }
        public float size { get { return default(float); } set {} }
        public float startEnergy { get { return default(float); } set {} }
        public Vector3 velocity { get { return default(Vector3); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class Motion : Object
    {
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AnimationEvent
    {
        public extern AnimationEvent();
         
        public AnimationState animationState { get { return default(AnimationState); } }
        public float floatParameter { get { return default(float); } set {} }
        public string functionName { get { return default(string); } set {} }
        public int intParameter { get { return default(int); } set {} }
        public SendMessageOptions messageOptions { get { return default(SendMessageOptions); } set {} }
        public Object objectReferenceParameter { get { return default(Object); } set {} }
        public string stringParameter { get { return default(string); } set {} }
        public float time { get { return default(float); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class AnimationCurve
    {
        public extern AnimationCurve();
        public extern AnimationCurve(params Keyframe[] keys);
         
        public Keyframe[] keys { get { return default(Keyframe[]); } set {} }
        public int length { get { return default(int); } }
        public WrapMode postWrapMode { get { return default(WrapMode); } set {} }
        public WrapMode preWrapMode { get { return default(WrapMode); } set {} }
         
        public Keyframe this[int index] { get { return default(Keyframe); } }
         
        public extern int AddKey(float time, float value);
        public extern int AddKey(Keyframe key);
        public extern float Evaluate(float time);
        public extern int MoveKey(int index, Keyframe key);
        public extern void RemoveKey(int index);
        public extern void SmoothTangents(int index, float weight);
        public static extern AnimationCurve EaseInOut(float timeStart, float valueStart, float timeEnd, float valueEnd);
        public static extern AnimationCurve Linear(float timeStart, float valueStart, float timeEnd, float valueEnd);
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public class BaseInputModule : UIBehaviour
    {
        public extern virtual void ActivateModule();
        public extern virtual void DeactivateModule();
        public extern virtual bool IsModuleSupported();
        public extern virtual bool IsPointerOverGameObject(int pointerId);
        public extern virtual void Process();
        public extern virtual bool ShouldActivateModule();
        public extern virtual void UpdateModule();
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public enum MoveDirection
    {
        Left = 0,
        Up = 1,
        Right = 2,
        Down = 3,
        None = 4,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum PhysicMaterialCombine
    {
        Average = 0,
        Minimum = 2,
        Multiply = 1,
        Maximum = 3,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum OffMeshLinkType
    {
        LinkTypeManual = 0,
        LinkTypeDropDown = 1,
        LinkTypeJumpAcross = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class OffMeshLink : Component
    {
        public extern OffMeshLink();
         
        public bool activated { get { return default(bool); } set {} }
        public bool autoUpdatePositions { get { return default(bool); } set {} }
        public bool biDirectional { get { return default(bool); } set {} }
        public float costOverride { get { return default(float); } set {} }
        public Transform endTransform { get { return default(Transform); } set {} }
        public int navMeshLayer { get { return default(int); } set {} }
        public bool occupied { get { return default(bool); } }
        public Transform startTransform { get { return default(Transform); } set {} }
         
         
        public extern void UpdatePositions();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct BoneWeight
    {
         
        public int boneIndex0 { get { return default(int); } set {} }
        public int boneIndex1 { get { return default(int); } set {} }
        public int boneIndex2 { get { return default(int); } set {} }
        public int boneIndex3 { get { return default(int); } set {} }
        public float weight0 { get { return default(float); } set {} }
        public float weight1 { get { return default(float); } set {} }
        public float weight2 { get { return default(float); } set {} }
        public float weight3 { get { return default(float); } set {} }
         
         
        public static extern bool operator ==(BoneWeight lhs, BoneWeight rhs);
        public static extern bool operator !=(BoneWeight lhs, BoneWeight rhs);
         
        public extern override bool Equals(object other);
        public extern override int GetHashCode();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct CombineInstance
    {
         
        public Mesh mesh { get { return default(Mesh); } set {} }
        public int subMeshIndex { get { return default(int); } set {} }
        public Matrix4x4 transform { get { return default(Matrix4x4); } set {} }
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum MeshTopology
    {
        Triangles = 0,
        Quads = 2,
        Lines = 3,
        LineStrip = 4,
        Points = 5,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RenderTextureFormat
    {
        ARGB32 = 0,
        Depth = 1,
        ARGBHalf = 2,
        RGB565 = 4,
        ARGB4444 = 5,
        ARGB1555 = 6,
        Default = 7,
        DefaultHDR = 9,
        ARGBFloat = 11,
        RGFloat = 12,
        RGHalf = 13,
        RFloat = 14,
        RHalf = 15,
        R8 = 16,
        ARGBInt = 17,
        RGInt = 18,
        RInt = 19,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RenderTextureReadWrite
    {
        Default = 0,
        Linear = 1,
        sRGB = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum CubemapFace
    {
        PositiveX = 0,
        NegativeX = 1,
        PositiveY = 2,
        NegativeY = 3,
        PositiveZ = 4,
        NegativeZ = 5,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public class TrackedReference
    {
        public static extern bool operator ==(TrackedReference x, TrackedReference y);
        public static extern implicit operator bool(TrackedReference exists);
        public static extern bool operator !=(TrackedReference x, TrackedReference y);
         
        public extern override bool Equals(object o);
        public extern override int GetHashCode();
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum AnimationBlendMode
    {
        Blend = 0,
        Additive = 1,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct CharacterInfo
    {
        public int index;
        public Rect uv;
        public Rect vert;
        public float width;
        public int size;
        public FontStyle style;
        public bool flipped;
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public enum RenderMode
    {
        ScreenSpaceOverlay = 0,
        ScreenSpaceCamera = 1,
        WorldSpace = 2,
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct UIVertex
    {
        public Vector3 position;
        public Vector3 normal;
        public Color32 color;
        public Vector2 uv0;
        public Vector2 uv1;
        public Vector4 tangent;
        public static UIVertex simpleVert;
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public interface ICanvasRaycastFilter
    {
        bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct UICharInfo
    {
        public Vector2 cursorPos;
        public float charWidth;
         
         
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct UILineInfo
    {
        public int startCharIdx;
        public int height;
         
         
    }
}
 
namespace System.Runtime.Serialization
{
    [Bridge.FileName("csw")]
    public struct SerializationEntry
    {
        public string Name { get { return default(string); } }
        public System.Type ObjectType { get { return default(System.Type); } }
        public object Value { get { return default(object); } }
         
         
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public class DecoderFallbackBuffer
    {
        public virtual int Remaining { get { return default(int); } }
         
         
        public extern virtual bool Fallback(byte[] bytesUnknown, int index);
        public extern virtual System.Char GetNextChar();
        public extern virtual bool MovePrevious();
        public extern virtual void Reset();
    }
}
 
namespace System.Text
{
    [Bridge.FileName("csw")]
    public class EncoderFallbackBuffer
    {
        public virtual int Remaining { get { return default(int); } }
         
         
        public extern virtual bool Fallback(System.Char charUnknownHigh, System.Char charUnknownLow, int index);
        public extern virtual bool Fallback(System.Char charUnknown, int index);
        public extern virtual System.Char GetNextChar();
        public extern virtual bool MovePrevious();
        public extern virtual void Reset();
    }
}
 
namespace UnityEngine.EventSystems
{
    [Bridge.FileName("csw")]
    public class BaseRaycaster : UIBehaviour
    {
        public virtual UnityEngine.Camera eventCamera { get { return default(UnityEngine.Camera); } }
        public virtual int renderOrderPriority { get { return default(int); } }
        public virtual int sortOrderPriority { get { return default(int); } }
         
         
        public extern virtual void Raycast(PointerEventData eventData, System.Collections.Generic.List<UnityEngine.EventSystems.RaycastResult> resultAppendList);
    }
}
 
namespace UnityEngine
{
    [Bridge.FileName("csw")]
    public struct Keyframe
    {
        public extern Keyframe(float time, float value);
        public extern Keyframe(float time, float value, float inTangent, float outTangent);
         
        public float inTangent { get { return default(float); } set {} }
        public float outTangent { get { return default(float); } set {} }
        public int tangentMode { get { return default(int); } set {} }
        public float time { get { return default(float); } set {} }
        public float value { get { return default(float); } set {} }
         
         
    }
}
 
#pragma warning restore 626, 824