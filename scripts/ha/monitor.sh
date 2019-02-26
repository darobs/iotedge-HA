#!/bin/bash
echo Starting EdgeAgent...
iotedgectl start

echo Monitoring EdgeAgent
while true
do
	DRESULT = `docker ps --filter "name=edgeAgent" --filter "status=running"`
	if [[ ${DRESULT} != *"edgeAgent"* ]]
	then
		break
	fi
	sleep .5
done

iotedgectl stop
echo Edge Agent container has crashed. Stopping monitoring.

