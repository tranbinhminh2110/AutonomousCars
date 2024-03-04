// App.js
import React from 'react';
import { Provider } from 'react-redux';
import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import store from './StorageToken/store';
import { Login, Signup, Welcome, TournamentList, Map, Match, HighSchool, ActivityType, Round } from './screen';

const Stack = createNativeStackNavigator();

export default function App() {
  return (
    <Provider store={store}>
      <NavigationContainer>
        <Stack.Navigator initialRouteName="Welcome">
          <Stack.Screen
            name="Welcome"
            component={Welcome}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="Login"
            component={Login}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="Signup"
            component={Signup}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="TournamentList"
            component={TournamentList}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="Map"
            component={Map}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="Match"
            component={Match}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="HighSchool"
            component={HighSchool}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="ActivityType"
            component={ActivityType}
            options={{ headerShown: false }}
          />
          <Stack.Screen
            name="Round"
            component={Round}
            options={{ headerShown: false }}
          />
        </Stack.Navigator>
      </NavigationContainer>
    </Provider>
  );
}
