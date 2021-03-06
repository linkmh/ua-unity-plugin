/*
 Copyright 2017 Urban Airship and Contributors
*/

package com.urbanairship.unityplugin;

import android.content.Context;
import android.support.annotation.NonNull;

import com.urbanairship.AirshipReceiver;
import com.urbanairship.push.PushMessage;

public class UnityAirshipReceiver extends AirshipReceiver {
    @Override
    protected void onChannelCreated(Context context, String channelId) {
        UnityPlugin.shared().onChannelCreated(channelId);
    }

    @Override
    protected void onChannelUpdated(Context context, String channelId) {
        UnityPlugin.shared().onChannelUpdated(channelId);
    }

    @Override
    protected void onPushReceived(@NonNull Context context, @NonNull PushMessage message, boolean notificationPosted) {
        UnityPlugin.shared().onPushReceived(message);
    }

    @Override
    protected boolean onNotificationOpened(@NonNull Context context, @NonNull NotificationInfo notificationInfo) {
        UnityPlugin.shared().onPushOpened(notificationInfo.getMessage());
        return false;
    }

    @Override
    protected boolean onNotificationOpened(@NonNull Context context, @NonNull NotificationInfo notificationInfo, @NonNull ActionButtonInfo actionButtonInfo) {
        UnityPlugin.shared().onPushOpened(notificationInfo.getMessage());
        return false;
    }
}
