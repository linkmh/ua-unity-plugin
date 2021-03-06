# Urban Airship Unity Plugin 2.3.0 to 3.0.0

## Android Minimum SDK Version

Urban Airship Android 8.0.1 SDK requires the minimum sdk version to be 16.

## iOS changes

Xcode 8+ is required for Urban Airship iOS 8.0.1 SDK.

Manually enable Push Notifications in the project editor's Capabilities pane:

![Enable Push Notifications](images/ios-enable-push-notifications.png)

# Urban Airship Unity Plugin 2.0.0 to 2.3.0

The Android Application override has been removed. Existing installations may need
to remove the UrbanAirshipApplication entry from `Assets/Plugins/Android/AndroidManifest.xml`.

# Urban Airship Unity Plugin 1.x.x to 2.0.0

The UA Unity Plugin 2.0.0 updates the interface to use C# properties and events.
Please refer to [Unity Plugin reference](https://docs.urbanairship.com/reference/libraries/unity/latest/index.html)
for the latest API docs.

## Plugin Interface

The plugin is now an instance `UAirship.Shared` instead of a collection of static methods.

The following methods have been removed and replaced with events:

```cs
// methods removed
public static void AddListener(GameObject gameObject)
public static void RemoveListener(GameObject gameObject)

// new events
public PushReceivedEventHandler OnPushReceived
```

The following methods have been removed and replaced with properties:

```cs
// methods removed
public static bool IsPushEnabled()
public static void EnablePush()
public static void DisablePush()

// new property
public bool UserNotificationsEnabled
```

```cs
// method removed
public static string GetTags()

// new property
public IEnumerable< string > Tags
```

```cs
// methods removed
public static void SetAlias(string alias)
public static string GetAlias()

// new property
public string Alias
```

```cs
// method removed
public static string GetChannelId()

// new property
public string ChannelId
```

```cs
// methods removed
public static bool IsLocationEnabled()
public static void EnableLocation()
public static void DisableLocation()

// new property
public bool LocationEnabled
```

```cs
// methods removed
public static bool IsBackgroundLocationEnabled()
public static void EnableBackgroundLocation()
public static void DisableBackgroundLocation()

// new property
public bool BackgroundLocationAllowed
```
