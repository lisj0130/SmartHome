import { useEffect } from 'react';
import { useGLTF } from '@react-three/drei';

export default function TvTable() {
    const { scene } = useGLTF('/models/tvtable.glb');

    return <primitive object={scene} scale={5} position={[-8.8, -3, -3]} rotation={[0, 0.5 * Math.PI, 0]} />;
}